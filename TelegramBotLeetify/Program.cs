using Telegram.Bot;
using Telegram.Bot.Types;
using OpenQA.Selenium.Chrome;
using TelegramBotLeetify.DriverFolder;
using TelegramBotLeetify.PageObject;
using TelegramBotLeetify.API;

namespace TelegramBotLeetify
{
    class Program
    {
        private static TelegramBotClient botClient;
        private static HttpClient httpClient = new HttpClient();

        static void Main()
        {
            // Инициализация бота с помощью токена
            botClient = new TelegramBotClient("6328737522:AAG2fyzT4UrpfQvD6P0pt5hyoJ8TwRorHiA");

            botClient.StartReceiving(Bot_OnMessage, Error);

            Console.WriteLine("Bot Started");
            Console.ReadLine();
        }

        private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        async static Task Bot_OnMessage(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {

                if (message.Text.Equals("/LastMatch"))
                {
                    botClient.SendTextMessageAsync(message.Chat.Id, "Collecting Latest Match Information, please wait...");
                    string response = await GetLastMatchStatsByApi();
                    await botClient.SendTextMessageAsync(message.Chat.Id, response);
                }
                if(message.Text.Equals("/LastMatchLink"))
                {
                    botClient.SendTextMessageAsync(message.Chat.Id, "Recieving Last Match Overview Link, please wait...");
                    string response = await GetLastMatchLinkByApi();
                    await botClient.SendTextMessageAsync(message.Chat.Id, response);
                }
            }
        }

        private static async Task<string> GetLastMatchStats()
        {
            ProfilePage profilePage = new ProfilePage();

            DriverBase.Driver = new ChromeDriver();
            DriverBase.Driver.Navigate().GoToUrl("https://leetify.com/public/profile/76561198199119538#match-history");
            DriverBase.ImplicitlyWaiter(10);
            DriverBase.Driver.Manage().Window.Maximize();

            var info = profilePage.GetOverAllInformationOfTheLastMatch();
            DriverBase.Driver.Quit();
            return info;

        }
        private static async Task<string> GetLastMatchOverviewLink()
        {
            ProfilePage profilePage = new ProfilePage();

            DriverBase.Driver = new ChromeDriver();
            DriverBase.Driver.Navigate().GoToUrl("https://leetify.com/public/profile/76561198199119538#match-history");
            DriverBase.ImplicitlyWaiter(10);
            DriverBase.Driver.Manage().Window.Maximize();

            var link = profilePage.GetLinkToLastMatchOverview();
            DriverBase.Driver.Quit();
            return link;

        }

        private static async Task<string> GetLastMatchStatsByApi()
        {
            APIRequests request = new APIRequests();

            return request.GetOverAllInformationOfTheLastMatchByApiCall();

        }

        private static async Task<string> GetLastMatchLinkByApi()
        {
            APIRequests request = new APIRequests();

            return request.GetLastMatchLinkByApiCall();

        }
    }
}