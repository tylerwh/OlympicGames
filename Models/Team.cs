namespace OlympicGames.Models
{
    public class Team
    {
        public string TeamID { get; set; }
        public string Name { get; set; }
        public Game Game { get; set; }
        public Category Category { get; set; }
        public string FlagImage { get; set; }
    }
}
