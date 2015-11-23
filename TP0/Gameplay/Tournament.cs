using System;
using System.Collections.Generic;
using TP0.Entity;

namespace TP0.Gameplay
{
    class Tournament
    {
        private List<Player> _players;
        private List<Pool> _pools;

        public Tournament(List<Player> players)
        {
            this._players = players;
            this._pools = new List<Pool>();
        }

        public void selectPools()
        {
			Console.WriteLine("Selection des équipes");

            List<Team> teams = new List<Team>();

            foreach(Player player in this._players)
            {
				Console.WriteLine("Ajout du joueur : " + player.name);
                teams.Add(player.teams[0]); // TODO : ajouter vérification
            }

            teams.Sort(compareTeamByVictory);

            int count = teams.Count;

            for (int i = 0; i < count; i += 2)
            {
                // Le cas où il y a un nombre impair d'équipe
                if (i + 1 >= count) {
                    break;
                }

                Pool pool = new Pool(teams[i], teams[i + 1]);

				Console.WriteLine("Création de la pool : " + pool);

                this._pools.Add(pool);
            }
        }

        public void match()
        {
            foreach(Pool pool in this._pools)
            {
				Console.WriteLine("Lancement du match : " + pool);
                Team team = pool.match();

				if (null != team) {
					Console.WriteLine (team.name + " est gagnante !");
					team.addVictory ();
				} else {
					Console.WriteLine("Aucune équipe gagnante");
				}
            }
        }

        private static int compareTeamByVictory(Team a, Team b)        
        {
            float aVictory = a.pourcentageVictory();
            float bVictory = b.pourcentageVictory();

            if (aVictory > bVictory) {
                return 1;
            } else if (bVictory > aVictory) {
                return -1;
            } else {
                return 0;
            }
        }
    }
}
