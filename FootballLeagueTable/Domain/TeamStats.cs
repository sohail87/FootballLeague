namespace FootballLeagueTable.Domain
{
    public class TeamStats
    {
        public string Team { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;

        public TeamStats(string team, int goalsFor, int goalsAgainst, int points)
        {
            Team = team;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            Points = points;
        }

        public static TeamStats Default(string team)
        {
            return new TeamStats(team, 0, 0, 0);
        }

        public TeamStats Win(int goalsFor, int goalsAgainst)
        {
            return new TeamStats(Team, GoalsFor + goalsFor, GoalsAgainst + goalsAgainst, Points + 3);
        }

        public TeamStats Loss(int goalsFor, int goalsAgainst)
        {
            return new TeamStats(Team, GoalsFor + goalsFor, GoalsAgainst + goalsAgainst, Points);
        }

        public TeamStats Draw(int goalsFor, int goalsAgainst)
        {
            return new TeamStats(Team, GoalsFor + goalsFor, GoalsAgainst + goalsAgainst, Points + 1);
        }
    }
}