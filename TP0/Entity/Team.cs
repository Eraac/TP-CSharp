using System.Collections.Generic;

namespace TP0.Entity
{
    class Team
    {
        private const int NB_GLADIATOR_MAX_PER_TEAM = 3;
        private string _name;
        private string _description;
        private List<Gladiator> _gladiators;
        private uint _nbMatchPlayed;
        private uint _nbMatchWon;

        public List<Gladiator> gladiators
        {
            get
            {
                return _gladiators;
            }
        }

        public Team(string name, string description, uint nbMatchPlayed = 0, uint nbMatchWon = 0)
        {
            this._name = name;
            this._description = description;
            this._gladiators = new List<Gladiator>();
            this._nbMatchPlayed = nbMatchPlayed;
            this._nbMatchWon = nbMatchWon;
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
