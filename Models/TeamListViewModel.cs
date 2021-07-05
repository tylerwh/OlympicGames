using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class TeamListViewModel
    {
        public List<Team> Teams { get; set; }
        public int ActiveCategory { get; set; }
        public int ActiveGame { get; set; }
        private List<Category> categories { get; set; }
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                categories.Insert(0, new Category { CategoryID = 0, Name = "All" }); // CategoryID of 0 for all
            }
        }
        private List<Game> games { get; set; }
        public List<Game> Games
        {
            get => games;
            set
            {
                games = value;
                games.Insert(0, new Game { GameID = 0, Name = "All" });
            }
        }

        public string CheckActiveCategory(int cat) => cat.Equals(ActiveCategory) ? "active" : "";
        public string CheckActiveGame(int g) => g.Equals(ActiveGame) ? "active" : "";
    }
}
