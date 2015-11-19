using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP0.Entity
{
    class Player
    {
        private const int NB_TEAM_MAX_PER_PLAYER = 5;
        private string _name;
        private string _firstname;
        private string _playerName;
        private DateTime _createAt;
        private List<Team> _teams;

        public string name { get; set; }
        public string firstname { get; set; }
        public string player_name { get; set; }
        public DateTime date_create { get; set; }
        public List<Team> teams { get; set; }

        public Player()
        {            
            this._createAt = new DateTime();
            this._teams = new List<Team>();
        }

        public bool addTeam(Team team)
        {
            int count = this._teams.Count;

            if (count >= NB_TEAM_MAX_PER_PLAYER)
            {
                return false;
            }

            this._teams.Add(team);

            return true;
        }
    }
}
