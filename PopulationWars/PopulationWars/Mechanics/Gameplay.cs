﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using PopulationWars.Map;
using PopulationWars.Components;
using System.Threading;

using static PopulationWars.Utilities.Constants;

namespace PopulationWars.Mechanics
{
    public class Gameplay
    {
        private List<Player> m_players;
        private World m_worldMap;
        private int m_turns;
        private double m_populationGrowthRate;

        private Action<Tuple<int, int>, Color, int> UpdateTile;
        private Action<Tuple<int, int>> LoadEnvironment;
        private Action<bool> RequestHumanPlayerMove;
        private Action ShowGameResult;

        public int CurrentTurn { get; private set; }
        public int Speed { get; set; }
        public bool SkipHumanPlayerTurn { get; set; }
        public bool SkipPlayerTurn { get; set; }
        public bool SkipGameTurn { get; set; }
        public bool HoldOn { get; set; }
        public bool StopGame { get; set; }
        public Decision PlayerDecision { get; set; }

        public Gameplay(Tuple<int, int> gameDuration, double populationGrowthRate,
            List<Player> players, World worldMap)
        {
            m_players = players;
            m_worldMap = worldMap;
            m_turns = new Random().Next(gameDuration.Item1, gameDuration.Item2);
            m_populationGrowthRate = populationGrowthRate;
            CurrentTurn = 0;
            Speed = 1;
        }

        public void CreateInitialColonies() =>
            m_players.ForEach(player =>
            {
                var tile = m_worldMap.GetRandomEmptyTile();
                player.CreateColony(tile, 100);
                UpdateTile(tile.Position, player.Color, 100);
            });

        public void Play() =>
            Task.Factory.StartNew(() =>
            {
                while (++CurrentTurn < m_turns)
                {
                    SkipGameTurn = false;
                    MakeGameTurn();

                    if (StopGame)
                        break;
                }

                ShowGameResult();
            });

        public void SetActions(Action<Tuple<int, int>, Color, int> tileUpdateAction,
            Action<Tuple<int, int>> environmentLoadAction, Action gameResultShowAction,
            Action<bool> humanPlayerMoveRequestAction)
        {
            UpdateTile = tileUpdateAction;
            LoadEnvironment = environmentLoadAction;
            ShowGameResult = gameResultShowAction;
            RequestHumanPlayerMove = humanPlayerMoveRequestAction;
        }

        private void MakeColonyTurn(Player player, Colony colony, Decision decision)
        {
            if (!decision.IsLeaving)
            {
                var population = (int)(colony.Population * m_populationGrowthRate);
                colony.Population = colony.Population > MaximumPopulationInColony ?
                    MaximumPopulationInColony : population;
                UpdateTile(colony.Tile.Position, player.Color, colony.Population);
                return;
            }

            var tileToMove = m_worldMap.GetNeighbourTile(colony.Tile, decision.Direction);

            if (tileToMove.IsWall)
            {
                return;
            }

            var populationToMove = (int)(colony.Population * decision.PopulationToMove) + 1;
            colony.Population -= populationToMove;
            UpdateTile(colony.Tile.Position, player.Color, colony.Population);

            if (colony.Population < 1)
            {
                player.DestroyColony(colony.Tile);
            }

            if (tileToMove.IsEmpty)
            {
                player.CreateColony(tileToMove, populationToMove);
                UpdateTile(tileToMove.Position, player.Color, populationToMove);
            }
            else
            {
                if (colony.Nation == tileToMove.OwnedBy.Nation)
                {
                    player.MoveToColony(tileToMove, populationToMove);
                    UpdateTile(tileToMove.Position, player.Color, tileToMove.OwnedBy.Population);
                }
                else
                {
                    var difference = populationToMove - tileToMove.OwnedBy.Population;
                    var enemy = m_players.Where(p => p.Nation == tileToMove.OwnedBy.Nation).
                        First();

                    if (difference > 0)
                    {
                        enemy.DestroyColony(tileToMove);
                        player.CreateColony(tileToMove, difference);
                        UpdateTile(tileToMove.Position, player.Color, difference);
                    }
                    else if (difference < 0)
                    {
                        tileToMove.OwnedBy.Population -= populationToMove;
                        UpdateTile(tileToMove.Position, enemy.Color,
                            tileToMove.OwnedBy.Population);
                    }
                    else
                    {
                        enemy.DestroyColony(tileToMove);
                        UpdateTile(tileToMove.Position, player.Color, 0);
                    }
                }
            }
        }

        private void MakeGameTurn() =>
            m_players.ForEach(player =>
            {
                SkipPlayerTurn = false;
                SkipHumanPlayerTurn = false;
                MakePlayerTurn(player);
            });

        private void MakePlayerTurn(Player player) =>
            new List<Colony>(player.Colonies).ForEach(colony =>
            {
                if (Speed < 32 && !SkipPlayerTurn && !SkipGameTurn || !player.IsAgent)
                    LoadEnvironment(colony.Tile.Position);

                Decision decision;
                if (player.IsAgent)
                {
                    // TODO: form situation
                    decision = colony.Nation.Government.MakeDecision(null);
                }
                else
                {
                    if (SkipHumanPlayerTurn)
                        decision = new Decision();
                    else
                    {
                        RequestHumanPlayerMove(true);
                        HoldOn = true;

                        while (HoldOn)
                            Thread.Sleep(1000);

                        decision = PlayerDecision;
                        RequestHumanPlayerMove(false);
                    }
                }

                MakeColonyTurn(player, colony, decision);

                while (HoldOn)
                    Thread.Sleep(1000);

                if (!SkipPlayerTurn && !SkipGameTurn)
                    Thread.Sleep(2048 / Speed);
            });
    }
}