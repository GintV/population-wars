﻿using System;
using System.Drawing;
using System.Collections.Generic;
using PopulationWars.Map;
using PopulationWars.Utilities;

namespace PopulationWars.Mechanics
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public World Map { get; set; }

        public Gameplay Gameplay { get; }
        public Settings Settings { get; }

        public Game(Settings settings, List<Player> players = null)
        {
            Players = players ?? new List<Player>();
            Map = new World(settings);
            Settings = settings;
            Gameplay = new Gameplay(settings.GameDuration, settings.PopulationGrowthRate,
                Players, Map);
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }

        public void StartGame(Action<Tuple<int, int>, Color, int> tileUpdateAction,
            Action<Tuple<int, int>> environmentLoadAction, Action gameResultShowAction,
            Action<bool> humanPlayerMoveRequestAction)
        {
            Gameplay.SetActions(tileUpdateAction, environmentLoadAction, gameResultShowAction,
                humanPlayerMoveRequestAction);
            Gameplay.CreateInitialColonies();
            Gameplay.Play();
        }
    }
}
