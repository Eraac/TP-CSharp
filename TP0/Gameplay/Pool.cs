using TP0.Entity;

namespace TP0.Gameplay
{
    class Pool
    {
        private Team _teamA;
        private Team _teamB;

        public Pool(Team teamA, Team teamB)
        {
            this._teamA = teamA;
            this._teamB = teamB;
        }

        public Team match()
        {
            this.addPlayedMatch();

            while (true)
            {
                Gladiator gladiatorA = this.getNextGladiatorTeamA();
                Gladiator gladiatorB = this.getNextGladiatorTeamB();

                if (null == gladiatorA && null != gladiatorB) {
                    return this._teamB;
                } else if (null != gladiatorA && null == gladiatorB) {
                    return this._teamA;
                } else if (null == gladiatorA && null == gladiatorB) {
                    return null;
                }
                else
                {
                    Duel duel = new Duel(gladiatorA, gladiatorB);
                    duel.fight();
                }
            }
        }

        private void addPlayedMatch()
        {
            this._teamA.addPlayedMatch();
            this._teamB.addPlayedMatch();
        }

        private Gladiator getNextGladiatorTeamA()
        {
            foreach(Gladiator gladiator in this._teamA.gladiators) {
                if (gladiator.isAlive()) {
                    return gladiator;
                }
            }

            return null;
        }

        private Gladiator getNextGladiatorTeamB()
        {
            foreach (Gladiator gladiator in this._teamB.gladiators) {
                if (gladiator.isAlive()) {
                    return gladiator;
                }
            }

            return null;
        }
    }
}
