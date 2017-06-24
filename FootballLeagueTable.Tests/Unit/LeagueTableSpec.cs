using System.Collections.Generic;
using System.Linq;
using FootballLeagueTable.Domain;
using FootballLeagueTable.Repositories;
using FootballLeagueTable.Tests.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FootballLeagueTable.Tests.Unit
{
    [TestClass]
    public class LeagueTableSpec
    {
        [TestMethod]
        public void ReturnTeamsInOrderOfPoints()
        {
            //arrange
            List<MatchResult> matchResults = MatchResultsFixtures.GetChampionByPoints();
            var mockResultsRepository = new Mock<IMatchResultsRepository>();
            mockResultsRepository.Setup(r => r.GetAll()).Returns(matchResults);
            //act
            var leagueTable = new LeagueTable(mockResultsRepository.Object);
            //assert
            Assert.AreEqual("Stoke", leagueTable.GetWinningTeamName());
        }

        [TestMethod]
        public void ReturnTeamsInOrderOfGoalDifference()
        {
            //arrange
            List<MatchResult> matchResults = MatchResultsFixtures.GetChampionByGoalDifference();
            var mockResultsRepository = new Mock<IMatchResultsRepository>();
            mockResultsRepository.Setup(r => r.GetAll()).Returns(matchResults);
            //act
            var leagueTable = new LeagueTable(mockResultsRepository.Object);
            //assert
            Assert.AreEqual("Liverpool", leagueTable.GetWinningTeamName());
        }

        [TestMethod]
        public void ReturnTeamsInOrderOfGoalsScored()
        {
            //arrange
            var matchResults = MatchResultsFixtures.GetChampionByGoalsScored();
            var mockResultsRepository = new Mock<IMatchResultsRepository>();
            mockResultsRepository.Setup(r => r.GetAll()).Returns(matchResults);
            //act
            var champion = new LeagueTable(mockResultsRepository.Object).GetWinningTeamName();
            //assert
            Assert.AreEqual("Stoke", champion);
        }
        [TestMethod]
        public void ReturnTeamsWithPositions()
        {
            //arrange
            var matchResults = MatchResultsFixtures.GetChampionByGoalsScored();
            var mockResultsRepository = new Mock<IMatchResultsRepository>();
            mockResultsRepository.Setup(r => r.GetAll()).Returns(matchResults);
            //act
            var standings = new LeagueTable(mockResultsRepository.Object).GetStandings();
            //assert
            var arsenalRank = standings.First(s => s.Team.Equals("Arsenal")).LeaguePosition;
            Assert.AreEqual(3, arsenalRank);
        }
        [TestMethod]
        public void ReturnTeamsAsEqualPositionsWhenSamePoints()
        {
            //arrange
            var matchResults = MatchResultsFixtures.GetTeamsWithEqualStats();
            var mockResultsRepository = new Mock<IMatchResultsRepository>();
            mockResultsRepository.Setup(r => r.GetAll()).Returns(matchResults);
            //act
            var standings = new LeagueTable(mockResultsRepository.Object).GetStandings();
            //assert
            Assert.AreEqual(1, standings.First(s => s.Team.Equals("Stoke")).LeaguePosition);
            Assert.AreEqual(2, standings.First(s => s.Team.Equals("Liverpool")).LeaguePosition);
            Assert.AreEqual(2, standings.First(s => s.Team.Equals("Man Utd")).LeaguePosition);
            Assert.AreEqual(4, standings.First(s => s.Team.Equals("Arsenal")).LeaguePosition);
        }


    }

}
