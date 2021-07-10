using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OlympicGames.Models
{
    public class OlympicCookies
    {
        private const string TeamsKey = "myteams";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public OlympicCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }

        public OlympicCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyTeamIds(List<Team> myteams)
        {
            List<string> ids = myteams.Select(t => t.TeamID).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            RemoveMyTeamIds();
            responseCookies.Append(TeamsKey, idsString, options);
        }

        public string[] GetMyTeamIds()
        {
            string cookie = requestCookies[TeamsKey];
            if (string.IsNullOrEmpty(cookie))
                return new string[] { };
            else
                return cookie.Split(Delimiter);
        }

        public void RemoveMyTeamIds()
        {
            responseCookies.Delete(TeamsKey);
        }
    }
}
