namespace FootballLeagueTable.Domain
{
    public class TeamPosition
    {
        private readonly TeamStats _teamStats;

        public string Team => _teamStats.Team;
        public int GoalsFor => _teamStats.GoalsFor;
        public int GoalsAgainst => _teamStats.GoalsAgainst;
        public int Points => _teamStats.Points;
        public int GoalDifference => _teamStats.GoalDifference;
        public int LeaguePosition { get; set; }

        public TeamPosition(TeamStats teamStats, int leaguePosition)
        {
            _teamStats = teamStats;
            LeaguePosition = leaguePosition;
        }

        public TeamPosition SetRank(TeamPosition newPosition)
        {
            return new TeamPosition(_teamStats, newPosition.LeaguePosition);
        }

        public override bool Equals(object obj)
        {
            var position = (TeamPosition) obj;

            return position.Points == Points
                   && position.GoalsFor == GoalsFor
                   && position.GoalDifference == GoalDifference;
        }

        public override int GetHashCode()
        {
            return Points.GetHashCode()
                   ^ GoalsFor.GetHashCode()
                   ^ GoalDifference.GetHashCode();
        }
    }
}