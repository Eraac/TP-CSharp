using System.Collections.Generic;
using TP0.Entity;

namespace TP0.Loader
{
    class LoadPlayer
    {
        public LoadPlayer() {}

        public List<Player> loadAll()
        {
            return new List<Player>();
        }

        public Player loadOne(string name)
        {
            return new Player("coucou", "coucou", "coucou");
        }
    }
}
