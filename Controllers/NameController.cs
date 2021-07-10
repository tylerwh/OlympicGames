using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;

namespace OlympicGames.Controllers
{
    public class NameController : Controller
    {
        public IActionResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveCategory = Int32.Parse(session.GetActiveCategory() == null ? "0" : session.GetActiveCategory()),
                ActiveGame = Int32.Parse(session.GetActiveGame() == null ? "0" : session.GetActiveGame()),
                Teams = session.GetMyTeams()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)
        {
            var session = new OlympicSession(HttpContext.Session);
            session.SetUserName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveCategory = Int32.Parse(session.GetActiveCategory() == null ? "0" : session.GetActiveCategory()),
                ActiveGame = Int32.Parse(session.GetActiveGame() == null ? "0" : session.GetActiveGame())
            });
        }
    }
}
