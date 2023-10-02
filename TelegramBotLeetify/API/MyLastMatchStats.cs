namespace TelegramBotLeetify.API
{
    public class MyLastMatchStats
    {
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public double KdRatio { get; set; }
        public int Multi2k { get; set; }
        public int Multi3k { get; set; }
        public int Multi4k { get; set; }
        public int Multi5k { get; set; }
        public double HltvRating { get; set; }
        public double Hsp { get; set; }
        public int RoundsSurvived { get; set; }
        public double RoundsSurvivedPercentage { get; set; }
        public double Dpr { get; set; }
        public int TotalAssists { get; set; }
        public int TotalDamage { get; set; }
        public int TradeKillOpportunities { get; set; }
        public int TradeKillAttempts { get; set; }
        public int TradeKillsSucceeded { get; set; }
        public double TradeKillAttemptsPercentage { get; set; }
        public double TradeKillsSuccessPercentage { get; set; }
        public double TradeKillOpportunitiesPerRound { get; set; }
        public int TradedDeathOpportunities { get; set; }
        public int TradedDeathAttempts { get; set; }
        public double TradedDeathAttemptsPercentage { get; set; }
        public int TradedDeathsSucceeded { get; set; }
        public double TradedDeathsSuccessPercentage { get; set; }
        public double TradedDeathsOpportunitiesPerRound { get; set; }
        public double LeetifyRating { get; set; }
        public double PersonalPerformanceRating { get; set; }
        public double CtLeetifyRating { get; set; }
        public double TLeetifyRating { get; set; }
        public string LeetifyUserId { get; set; }
    }
}
