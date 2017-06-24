using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballLeagueTable.Domain;
using FootballLeagueTable.Repositories;


namespace FootballLeagueTable.Website.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var league = GetLeagueStandings();
            return View("Index", league);
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            ServerResultsFile.DeleteAll();
            ServerResultsFile.Save(file);

            var league = GetLeagueStandings();
            return View("Index", league);
        }


        public ActionResult MatchResults(string teamName)
        {
            ViewBag.Title = $"{teamName} Match Results";
            var results = new MatchResultsRepository(ServerResultsFile.Get()).GetBy(teamName);
            return View("MatchResults", results);
        }

        private static List<TeamPosition> GetLeagueStandings()
        {
            return new LeagueTable(new MatchResultsRepository(ServerResultsFile.Get())).GetStandings();
        }
    }
}