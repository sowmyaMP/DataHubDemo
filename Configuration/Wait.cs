namespace DataHubDemo.Configuration
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public static class Wait
    {
        private static IWebElement page = null;
        private static IWebDriver driver = Driver.Browser;

        public static void WaitForPageLoad()
        {
            try
            {
                if (page != null)
                {
                    var waitForCurrentPageToStale = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    waitForCurrentPageToStale.Until(ExpectedConditions.StalenessOf(page));
                }

                var waitForDocumentReady = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitForDocumentReady.Until((wdriver) => (driver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));

                page = driver.FindElement(By.TagName("html"));
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        public static bool CheckForElementExistance(IWebDriver driver, By by)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists(by));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(angularIsDoneLoading);
        // Add the rest of your code in here(like finding element, clicking on it etc.)

        // Func<IWebDriver, bool> angularIsDoneLoading = (IWebDriver drv) =>
        // {
        //    string ngFinishedAllRequests =
        //         @"var injector = window.angular.element('body').injector();
        //             var $http = injector.get('$http');
        //             return ($http.pendingRequests.length === 0)";

        // return ((IJavaScriptExecutor)drv).ExecuteScript(ngFinishedAllRequests).ToString() == "True";
        // };
        // new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(angularIsDoneLoading);
    }
}
