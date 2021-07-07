using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlympicGames.Models
{
    public class OlympicSession
    {
        private const string TeamsKey = "myteams";
        private const string CountKey = "teamcount";
        private const string CategoryKey = "category";
        private const string GameKey = "game";

        private ISession session { get; set; }
        public OlympicSession(ISession session)
        {
            this.session = session;
        }

        public void SetUserName(string userName) => session.SetString("UserName", userName);
        public string GetUserName() => session.GetString("UserName");

        public void SetMyTeams(List<Team> teams)
        {
            session.SetObject(TeamsKey, teams); // extension from SessionExtensions.cs
            session.SetInt32(CountKey, teams.Count);
        }
        public List<Team> GetMyTeams() => 
            session.GetObject<List<Team>>(TeamsKey) ?? new List<Team>();

        public int? GetMyTeamsCount() => session.GetInt32(CountKey);

        public void SetActiveCategory(string cat) =>
            session.SetString(CategoryKey, cat);
        public string GetActiveCategory() => session.GetString(CategoryKey);

        public void SetActiveGame(string game) =>
            session.SetString(GameKey, game);

        public string GetActiveGame() => session.GetString(GameKey);

        public void RemoveMyTeams()
        {
            session.Remove(TeamsKey);
            session.Remove(CountKey);
        }
    }
}
