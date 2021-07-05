using Microsoft.EntityFrameworkCore;

namespace OlympicGames.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = 1, Name = "Summer Olympics" },
                new Game { GameID = 2, Name = "Winter Olympics" },
                new Game { GameID = 3, Name = "Paralympic Games" },
                new Game { GameID = 4, Name = "Youth Olympics" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Indoor" },
                new Category { CategoryID = 2, Name = "Outdoor" }
            );
            modelBuilder.Entity<Team>().HasData(
                new { TeamID = "aus", Name = "Austria", GameID = 3, CategoryID = 2, FlagImage = "AUS.png" },
                new { TeamID = "brz", Name = "Brazil", GameID = 1, CategoryID = 2, FlagImage = "BRZ.gif" },
                new { TeamID = "can", Name = "Canada", GameID = 2, CategoryID = 1, FlagImage = "CAN.png" },
                new { TeamID = "chn", Name = "China", GameID = 1, CategoryID = 1, FlagImage = "CHN.gif" },
                new { TeamID = "cyp", Name = "Cyprus", GameID = 4, CategoryID = 1, FlagImage = "CYP.gif" },
                new { TeamID = "fin", Name = "Finland", GameID = 4, CategoryID = 2, FlagImage = "FIN.jpg" },
                new { TeamID = "fra", Name = "France", GameID = 4, CategoryID = 1, FlagImage = "FRA.gif" },
                new { TeamID = "ger", Name = "Germany", GameID = 1, CategoryID = 1, FlagImage = "GER.gif" },
                new { TeamID = "gbr", Name = "Great Britain", GameID = 2, CategoryID = 1, FlagImage = "GBR.jpg" },
                new { TeamID = "ita", Name = "Italy", GameID = 2, CategoryID = 2, FlagImage = "ITA.gif" },
                new { TeamID = "jam", Name = "Jamaica", GameID = 2, CategoryID = 2, FlagImage = "JAM.gif" },
                new { TeamID = "jap", Name = "Japan", GameID = 2, CategoryID = 2, FlagImage = "JAP.gif" },
                new { TeamID = "mex", Name = "Mexico", GameID = 1, CategoryID = 1, FlagImage = "MEX.png" },
                new { TeamID = "net", Name = "Netherlands", GameID = 1, CategoryID = 2, FlagImage = "NET.png" },
                new { TeamID = "pak", Name = "Pakistan", GameID = 3, CategoryID = 2, FlagImage = "PAK.png" },
                new { TeamID = "por", Name = "Portugal", GameID = 4, CategoryID = 2, FlagImage = "POR.png" },
                new { TeamID = "rus", Name = "Russia", GameID = 4, CategoryID = 1, FlagImage = "RUS.png" },
                new { TeamID = "slo", Name = "Slovakia", GameID = 4, CategoryID = 2, FlagImage = "SLO.jpg" },
                new { TeamID = "swe", Name = "Sweden", GameID = 2, CategoryID = 1, FlagImage = "SWE.jpg" },
                new { TeamID = "thi", Name = "Thailand", GameID = 3, CategoryID = 1, FlagImage = "THI.png" },
                new { TeamID = "ukr", Name = "Ukraine", GameID = 3, CategoryID = 1, FlagImage = "UKR.jpg" },
                new { TeamID = "uru", Name = "Uruguay", GameID = 3, CategoryID = 1, FlagImage = "URU.png" },
                new { TeamID = "usa", Name = "USA", GameID = 1, CategoryID = 2, FlagImage = "USA.png" },
                new { TeamID = "zim", Name = "Zimbabwe", GameID = 3, CategoryID = 2, FlagImage = "ZIM.gif" }
            );
        }
    }
}
