using System;
using FootballLeagueTable.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballLeagueTable.Tests.Integration
{
    [TestClass]
    public class MatchResultsRepositoryTests
    {
        private IMatchResultsRepository _matchResultsRepository;

        [TestInitialize]
        public void TestSetup()
        {
            //arrange
            var matchResultsFilePath = "./SourceFile/PL-2015-2016.csv";
            _matchResultsRepository = new MatchResultsRepository(matchResultsFilePath);
        }
        [TestMethod]
        public void ReturnSingleTeamResults()
        {
            //act
            var teamMatchResults = _matchResultsRepository.GetBy("Stoke");
            //assert
            Assert.AreEqual(38, teamMatchResults.Count);
        }
        [TestMethod]
        public void ReturnAllResults()
        {
            //act
            var teamMatchResults = _matchResultsRepository.GetAll();
            //assert
            Assert.AreEqual(380, teamMatchResults.Count);
        }
    }
}
