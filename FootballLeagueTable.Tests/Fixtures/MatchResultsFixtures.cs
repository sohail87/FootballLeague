using System;
using System.Collections.Generic;
using FootballLeagueTable.Domain;

namespace FootballLeagueTable.Tests.Fixtures
{
    public class MatchResultsFixtures
    {
        public static List<MatchResult> GetChampionByPoints()
        {
            return new List<MatchResult>
            {
                new MatchResult  { Date = DateTime.Now, HomeTeam = "Liverpool", AwayTeam = "Man Utd", FTHG = 3, FTAG = 3, FTR = 'D' },
                new MatchResult  { Date = DateTime.Now, HomeTeam = "Stoke", AwayTeam = "Arsenal", FTHG = 6, FTAG = 2, FTR = 'H' }
            };
        }

        public static List<MatchResult> GetChampionByGoalDifference()
        {
            return new List<MatchResult>
            {
                new MatchResult  { Date = DateTime.Now, HomeTeam = "Stoke", AwayTeam = "Arsenal", FTHG = 3, FTAG = 2, FTR = 'H' },
                new MatchResult  { Date = DateTime.Now, HomeTeam = "Liverpool", AwayTeam = "Man Utd", FTHG = 6, FTAG = 2, FTR = 'H' }
            };
        }

        public static List<MatchResult> GetChampionByGoalsScored()
        {
            return new List<MatchResult>
            {
                new MatchResult {Date = DateTime.Now, HomeTeam = "Stoke", AwayTeam = "Arsenal", FTHG = 10, FTAG = 9, FTR = 'H'},
                new MatchResult {Date = DateTime.Now, HomeTeam = "Liverpool", AwayTeam = "Man Utd", FTHG = 3, FTAG = 2, FTR = 'H'},
                new MatchResult {Date = DateTime.Now, HomeTeam = "Arsenal", AwayTeam = "Stoke", FTHG = 2, FTAG = 3, FTR = 'A'},
                new MatchResult {Date = DateTime.Now, HomeTeam = "Man Utd", AwayTeam = "Liverpool", FTHG = 2, FTAG = 3, FTR = 'A'}
            };
        }

        public static List<MatchResult> GetTeamsWithEqualStats()
        {
            return new List<MatchResult>
            {
                new MatchResult {Date = DateTime.Now, HomeTeam = "Stoke", AwayTeam = "Arsenal", FTHG = 10, FTAG = 9, FTR = 'H'},
                new MatchResult {Date = DateTime.Now, HomeTeam = "Liverpool", AwayTeam = "Man Utd", FTHG = 3, FTAG = 3, FTR = 'D'},
            };
        }
    
    }
}