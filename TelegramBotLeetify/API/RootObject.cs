namespace TelegramBotLeetify.API
{
    public class RootObject
    {
        public List<GamesOrMatches> Games { get; set; }

        public List<MyLastMatchStats> PlayerStats { get; set; }
    }
}
