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

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public string firstname
        {
            get
            {
                return _firstname;
            }

            set
            {
                _firstname = value;
            }
        }
        public string playerName
        {
            get
            {
                return _playerName;
            }

            set
            {
                _playerName = value;
            }
        }
        public DateTime createAt
        {
            get
            {
                return _createAt;
            }

            set
            {
                _createAt = value;
            }
        }
        public List<Team> teams
        {
            get
            {
                return _teams;
            }
        }

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

        public override string ToString()
        {
            String teamString = "";            

            foreach(Team team in this._teams) {
                teamString += team.ToString() + " / ";
            }

            return "[player] : " + this._name + " - " + this._firstname + " - " + this._playerName + " | teams : " + teamString;
        }
    }
}
