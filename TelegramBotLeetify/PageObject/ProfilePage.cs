using OpenQA.Selenium;
using System.Text.RegularExpressions;
using TelegramBotLeetify.DriverFolder;

namespace TelegramBotLeetify.PageObject
{
    public class ProfilePage
    {

        public IWebElement MatchHistoryTable => DriverBase.Driver.FindElement(By.XPath("//app-profile-match-history"));

        public List <IWebElement> Matches => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath("//app-profile-match-history //a //td[1]")).ToList();

        public List<IWebElement> MatchDate => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath(" //td[contains(@class, '--right')][1]")).ToList();

        public List<IWebElement> MatchScore => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath(" //td[contains(@class,'--center text')]")).ToList();

        public List<IWebElement> MatchMap => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath("//app-profile-match-history //td/div[contains(@_ngcontent-serverapp-c155,'')]")).ToList();

        public List<IWebElement> MatchRank => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath("//section[contains(@id,'match-history')] //div //img")).ToList();

        public List<IWebElement> MatchValueRating => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath(" //td[contains(@class,'--right text')]")).ToList();

        public List<IWebElement> MatchKills => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath(" //td[contains(@class, '--right')][3]")).ToList();
        public List<IWebElement> MatchDeaths => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath(" //td[contains(@class, '--right')][4]")).ToList();
        public List<IWebElement> MatchKD => (List<IWebElement>)DriverBase.Driver.FindElements(By.XPath(" //td[contains(@class, '--right')][5]")).ToList();

        public double MatchRankNumber()
        {
            var altAttributeValue =  MatchRank.FirstOrDefault().GetAttribute("alt");

            Match match = Regex.Match(altAttributeValue, @"\d+(,\d+)?");
            var rankNumber = double.Parse(match.Value);
            return rankNumber;
        }

        public string GetOverAllInformationOfTheLastMatch()
        {
            return $"Stats for the last game: " +
                $"\nMap - {MatchMap.First().Text} " +
                $"\nMatch Date - {MatchDate.FirstOrDefault().Text} " +
                $"\nMatch Score - {MatchScore.FirstOrDefault().Text} " +
                $"\nCurrent Rank - {MatchRankNumber()} " +
                $"\nValue Rating - {MatchValueRating.FirstOrDefault().Text}" +
                $"\nKills - {MatchKills.FirstOrDefault().Text}" +
                $"\nDeaths - {MatchDeaths.FirstOrDefault().Text}" +
                $"\nK/D - {MatchKD.FirstOrDefault().Text}";
        }

        public string GetLinkToLastMatchOverview()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Matches.FirstOrDefault().Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return DriverBase.Driver.Url;
        }
    }
}
