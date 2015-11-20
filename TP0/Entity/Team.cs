using System.Collections.Generic;

namespace TP0.Entity
{
    class Team
    {
        private const int NB_GLADIATOR_MAX_PER_TEAM = 3;
        private string _name;
        private string _description;
        private uint _nbMatchPlayed;
        private uint _nbMatchWon;
        private List<Gladiator> _gladiators;

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
        public string description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public uint nbMatchPlayed
        {
            get
            {
                return _nbMatchPlayed;
            }

            set
            {
                _nbMatchPlayed = value;
            }
        }
        public uint nbMatchWon
        {
            get
            {
                return _nbMatchWon;
            }

            set
            {
                _nbMatchWon = value;
            }
        }
        public List<Gladiator> gladiators
        {
            get
            {
                return _gladiators;
            }

            set
            {
                _gladiators = value;
            }
        }


        public Team()
        {
            this._gladiators = new List<Gladiator>();
        }

        public float pourcentageVictory()
        {
            float pourcentage = 0f;

            foreach(Gladiator gladiator in this._gladiators)
            {
                pourcentage += gladiator.pourcentageVictory();
            }

            pourcentage /= this._gladiators.Count;

            return pourcentage;
        }

        public void addPlayedMatch(bool victory)
        {
            foreach (Gladiator gladiator in this._gladiators)
            {
                gladiator.addMatch(victory);
            }
        }

        public bool addGladiator(Gladiator gladiator)
        {
            int nbGladiator = this._gladiators.Count;

            if (nbGladiator >= NB_GLADIATOR_MAX_PER_TEAM)
            {
                return false;
            }

            this._gladiators.Add(gladiator);

            return true;
        }
    }
}
