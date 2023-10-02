using OpenQA.Selenium;

namespace TelegramBotLeetify.DriverFolder
{
    public static class DriverBase
    {
        public static IWebDriver Driver { get; set; }

        public static void ImplicitlyWaiter(int timeToWait)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }
    }
}
