namespace TelegramBotLeetify.API
{
    public class GamesOrMatches
    {
        public string GameId { get; set; }
        public string GameFinishedAt { get; set; }
        public string MapName { get; set; }
        public string MapResult { get; set; }
        public int[] Scores { get; set; }
        public string SkillLevel { get; set; }
        public string DataSource {  get; set; }
    }
}
