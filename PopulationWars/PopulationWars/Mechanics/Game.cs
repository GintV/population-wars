using PopulationWars.Map;
using PopulationWars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Mechanics
{
    class Game
    {
        public List<Player> Players { get; set; }
        public World Map { get; set; }

        public MovesController MovesController { get; set; }

        public Game()
        {
            Players = new List<Player>();
            Map = new World();
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
