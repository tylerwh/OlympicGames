using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;
using System;

namespace OlympicGames.Controllers
{
    public class FavoritesController : Controller
    {
        [HttpGet]
        public ViewResult Index()
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
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            var cookies = new OlympicCookies(HttpContext.Response.Cookies);

            session.RemoveMyTeams();
            cookies.RemoveMyTeamIds();

            TempData["message"] = "Favorite Teams Cleared";

            return RedirectToAction("Index", "Home", new
            {
                ActiveCategory = Int32.Parse(session.GetActiveCategory() == null ? "0" : session.GetActiveCategory()),
                ActiveGame = Int32.Parse(session.GetActiveGame() == null ? "0" : session.GetActiveGame())
            });
        }
    }
}
