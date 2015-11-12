using TP0.Entity;
using TP0.Gameplay;
using System.Collections.Generic;

namespace TP0
{
    class Game
    {
        public Game() {}

        public void run()
        {
            // TODO 1. Load players
            List<Player> players = new List<Player>();

            // 2. Run tournament
            Tournament tournament = new Tournament(players);
        }
    }
}
