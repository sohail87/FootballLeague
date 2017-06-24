using System.Collections.Generic;
using FootballLeagueTable.Domain;

namespace FootballLeagueTable.Repositories
{
    public interface IMatchResultsRepository
    {
        List<MatchResult> GetAll();
        List<MatchResult> GetBy(string team);
    }
}