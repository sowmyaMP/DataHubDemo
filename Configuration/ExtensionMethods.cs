namespace DataHubDemo.Configuration
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public static class ExtensionMethods
    {
        public static IWebElement FindElementOnPage(this IWebDriver webDriver, By by)
        {
            RemoteWebElement element = (RemoteWebElement)webDriver.FindElement(by);
            var hack = element.LocationOnScreenOnceScrolledIntoView;
            return element;
        }
    }
}
