using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class HomeController : Controller
    {
        private TeamContext context;
        public HomeController(TeamContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(int activeCategory = 0, int activeGame = 0)
        {
            var model = new TeamListViewModel
            {
                ActiveCategory = activeCategory,
                ActiveGame = activeGame,
                Categories = context.Categories.ToList(),
                Games = context.Games.ToList()
            };

            IQueryable<Team> query = context.Teams;
            if(!activeCategory.Equals(0))
                query = query.Where(t => t.Category.CategoryID.Equals(activeCategory));
            if (!activeGame.Equals(0))
                query = query.Where(t => t.Game.GameID.Equals(activeGame));

            model.Teams = query.ToList();

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new TeamViewModel
            {
                Team = context.Teams.Include(t => t.Category).Include(t => t.Game).FirstOrDefault(t => t.TeamID == id),
                ActiveCategory = session.GetActiveCategory(),
                ActiveGame = session.GetActiveGame()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(TeamViewModel model)
        {
            model.Team = context.Teams
                .Include(t => t.Category)
                .Include(t => t.Game)
                .Where(t => t.TeamID == model.Team.TeamID)
                .FirstOrDefault();

            var session = new OlympicSession(HttpContext.Session);
            var teams = session.GetMyTeams();
            teams.Add(model.Team);
            session.SetMyTeams(teams);

            return RedirectToAction("Index",
                new
                {
                    ActiveCategory = session.GetActiveCategory(),
                    ActiveGame = session.GetActiveGame()
                });
        }
        
    }
}
