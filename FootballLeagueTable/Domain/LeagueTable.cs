using System.Collections.Generic;
using System.Linq;
using FootballLeagueTable.Repositories;

namespace FootballLeagueTable.Domain
{
    public class LeagueTable : MatchResult.IMatchResultListener
    {
        private readonly List<MatchResult> _matchResults;

        private Dictionary<string, TeamStats> _teamStats;

        public LeagueTable(IMatchResultsRepository resultsRepository)
        {
            _matchResults = resultsRepository.GetAll();
            InitialiseTeamStats();
            ProcessResults();
        }

        public List<TeamPosition> GetStandings()
        {
            var rank = 1;

            var teamPositions =_teamStats.Select(t => t.Value)
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t=>t.GoalDifference)
                .ThenByDescending(t=>t.GoalsFor)
                .Select(t=> new TeamPosition(t, rank++))
                .ToList();

            return teamPositions
                .Select(pos => pos.SetRank(FindMatchingTeamPosition(pos, teamPositions)))
                .ToList();

        }

        public string GetWinningTeamName()
        {
            return GetStandings().First().Team;
        }
        
        public void UpdateLeagueWhenHomeTeamWins(MatchResult matchResult)
        {
            _teamStats[matchResult.HomeTeam] = _teamStats[matchResult.HomeTeam].Win(matchResult.FTHG, matchResult.FTAG);
            _teamStats[matchResult.AwayTeam] = _teamStats[matchResult.AwayTeam].Loss(matchResult.FTAG, matchResult.FTHG);
        }

        public void UpdateLeagueWhenAwayTeamWins(MatchResult matchResult)
        {
            _teamStats[matchResult.HomeTeam] = _teamStats[matchResult.HomeTeam].Loss(matchResult.FTHG, matchResult.FTAG);
            _teamStats[matchResult.AwayTeam] = _teamStats[matchResult.AwayTeam].Win(matchResult.FTAG, matchResult.FTHG);
        }

        public void UpdateLeagueWhenTeamsDraw(MatchResult matchResult)
        {
            _teamStats[matchResult.HomeTeam] = _teamStats[matchResult.HomeTeam].Draw(matchResult.FTHG, matchResult.FTAG);
            _teamStats[matchResult.AwayTeam] = _teamStats[matchResult.AwayTeam].Draw(matchResult.FTAG, matchResult.FTHG);
        }

        private void InitialiseTeamStats()
        {
            _teamStats = _matchResults
                .Select(mr => mr.HomeTeam)
                .Union(_matchResults.Select(mr => mr.AwayTeam))
                .Distinct()
                .ToDictionary(mr => mr, TeamStats.Default);
        }
        private void ProcessResults()
        {
            _matchResults.ForEach(m => m.GetResult(this));
        }
        private TeamPosition FindMatchingTeamPosition(TeamPosition currentPosition, List<TeamPosition> positions)
        {
            return positions
                .DefaultIfEmpty(currentPosition)
                .FirstOrDefault(p => p.Equals(currentPosition));
        }
    }
}