using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public string ActiveCategory { get; set; }
        public string ActiveGame { get; set; }
    }
}
