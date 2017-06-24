using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using FootballLeagueTable.Domain;

namespace FootballLeagueTable.Repositories
{
    public class MatchResultsRepository : IMatchResultsRepository
    {
        private readonly List<MatchResult> _results;

        public MatchResultsRepository(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (TextReader reader = File.OpenText(filePath))
                {
                    var csv = new CsvReader(reader);
                    _results = csv.GetRecords<MatchResult>().ToList();
                }
            }
            else
            {
                _results = new List<MatchResult>();
            }
        }

        public List<MatchResult> GetAll()
        {
            return _results;
        }
        public List<MatchResult> GetBy(string team)
        {
            var homeResults = _results.Select(r => r).Where(r => r.HomeTeam == team);
            var awayResults = _results.Select(r => r).Where(r => r.AwayTeam == team);

            return homeResults.Union(awayResults).OrderBy(r=>r.Date).ToList();
        }
    }
}
