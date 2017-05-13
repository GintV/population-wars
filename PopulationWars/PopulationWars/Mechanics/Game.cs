using System.Collections.Generic;
using PopulationWars.Map;
using PopulationWars.Utilities;

namespace PopulationWars.Mechanics
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public World Map { get; set; }

        public MovesController MovesController { get; set; }

        public Game(Settings settings)
        {
            Players = new List<Player>();
            Map = new World(settings);
            MovesController = new MovesController();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
    }
}
