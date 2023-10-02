using Newtonsoft.Json;
using RestSharp;

namespace TelegramBotLeetify.API
{
    public  class APIRequests
    {
        public string GetOverAllInformationOfTheLastMatchByApiCall()
        {
            var client = new RestClient("https://api.leetify.com");

            // Create a RestRequest for the GET request
            var request = new RestRequest("/api/profile/76561198199119538", Method.Get);

            var response = client.Execute(request);

            RootObject root = JsonConvert.DeserializeObject<RootObject>(response.Content);

            GamesOrMatches LastGame = root.Games[0];

            var LastGameId = LastGame.GameId;

            var scoreResult = string.Join(":", LastGame.Scores);

            request = new RestRequest($"api/games/{LastGameId}", Method.Get);
            response = client.Execute(request);

            root = JsonConvert.DeserializeObject<RootObject>(response.Content);

            MyLastMatchStats LastMatchStats = root.PlayerStats.FirstOrDefault(stats => stats.LeetifyUserId == "c8063427-1b18-4299-aa15-bdffd0f710c6");

            return $"Stats for the last game: " +
                $"\nMap - {LastGame.MapName} " +
                $"\nMatch Date - {LastGame.GameFinishedAt} " +
                $"\nMatch Type - {LastGame.DataSource} " +
                $"\nMatch Score - {scoreResult} " +
                $"\nCurrent Rank - {LastGame.SkillLevel} " +
                $"\nValue Rating - {LastMatchStats.LeetifyRating}" +
                $"\nKills - {LastMatchStats.TotalKills}" +
                $"\nDeaths - {LastMatchStats.TotalDeaths}" +
                $"\nK/D - {LastMatchStats.KdRatio}";
        }

        public string GetLastMatchLinkByApiCall()
        {
            var client = new RestClient("https://api.leetify.com");

            // Create a RestRequest for the GET request
            var request = new RestRequest("/api/profile/76561198199119538", Method.Get);

            var response = client.Execute(request);

            RootObject root = JsonConvert.DeserializeObject<RootObject>(response.Content);

            GamesOrMatches LastGame = root.Games[0];

            var LastGameId = LastGame.GameId;

            return $"Link for the last game: " +
                $" https://leetify.com/app/match-details/{LastGameId}/overview ";
                
        }
    }
}
