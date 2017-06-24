using System;

namespace FootballLeagueTable.Domain
{
    public class MatchResult
    {
        public interface IMatchResultListener
        {
            void UpdateLeagueWhenHomeTeamWins(MatchResult matchResult);
            void UpdateLeagueWhenAwayTeamWins(MatchResult matchResult);
            void UpdateLeagueWhenTeamsDraw(MatchResult matchResult);
        }

        public DateTime Date { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int FTHG { get; set; }
        public int FTAG { get; set; }
        public char FTR { get; set; }
        public int HTHG { get; set; }
        public int HTAG { get; set; }
        public char HTR { get; set; }
        public string Referee { get; set; }


        public void GetResult(IMatchResultListener listener)
        {
            if (IsHomeWin())
            {
                listener.UpdateLeagueWhenHomeTeamWins(this);
                return;
            }

            if (IsAwayWin())
            {
                listener.UpdateLeagueWhenAwayTeamWins(this);
                return;
            }

            listener.UpdateLeagueWhenTeamsDraw(this);

        }

        private bool IsAwayWin()
        {
            return FTR.Equals('A');
        }

        private bool IsHomeWin()
        {
            return FTR.Equals('H');
        }
    }
}