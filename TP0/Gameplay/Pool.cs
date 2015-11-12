using TP0.Entity;

namespace TP0.Gameplay
{
    class Pool
    {
        private const uint NB_MAX_TEAM_PER_POOL = 2;
        private Team[] _teams;

        public Pool(Team teamA, Team teamB)
        {
            this._teams = new Team[NB_MAX_TEAM_PER_POOL];
            this._teams[0] = teamA;
            this._teams[1] = teamA;
        }

        public Team match()
        {
            // TODO
            return this._teams[0];
        }
    }
}
