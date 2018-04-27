
namespace DataHubDemo.Pages.Main
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using DataHubDemo.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.PageObjects;   
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;
    using SeleniumExtras.WaitHelpers;

    public  class BasePage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IWebDriver pageDriver;
        public String parentWindow;
        private static IWebElement page = null;
        By PageLoad = By.CssSelector("body > div.loading-indicator.page-loading-indicator");
        public OpenQA.Selenium.Support.UI.WebDriverWait webDriverWait;
        public BasePage(IWebDriver driver)
        {
            pageDriver = driver;
            pageDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            pageDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1000);
            pageDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(0);
            webDriverWait = new OpenQA.Selenium.Support.UI.WebDriverWait(pageDriver, TimeSpan.FromSeconds(300));
        }



        public  void WaitForPageLoad()
        {
            try
            {
                if (page != null)
                {
                    var waitForCurrentPageToStale = new WebDriverWait(pageDriver, TimeSpan.FromSeconds(10));
                    waitForCurrentPageToStale.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(page));
                }

                var waitForDocumentReady = new WebDriverWait(pageDriver, TimeSpan.FromSeconds(10));
                waitForDocumentReady.Until((wdriver) => (pageDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));

                page = pageDriver.FindElement(By.TagName("html"));
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        public void getURL(String url)
        {
            log.Debug("Before getURL with URL::" + url);
            //        getDriver().manage().deleteAllCookies();
            pageDriver.Manage().Window.Maximize();
            pageDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            pageDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1000);
            pageDriver.Url = url;
            log.Debug("After getURL with URL::" + url);
        }

        public IWebElement waitForElement(By byElement)
        {

            IWebElement element = null;
            log.Info("Before waitForElement::" + byElement);
            try
            {
                //            webDriverWait.until(ExpectedConditions.presenceOfElementLocated(byElement));
                element = pageDriver.FindElement(byElement);
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byElement));
            }
            catch (Exception e)
            {
                log.Warn(e.StackTrace);
                log.Error(e.Message);
            }
            log.Info("After waitForElement::" + byElement);
            return element;
        }


        public IWebElement waitForElementClickable( By byElement)
        {

            IWebElement element = null;
            log.Info("Before waitForElement::" + byElement);
            try
            {
                //            webDriverWait.until(ExpectedConditions.elementToBeClickable(byElement));
                element = pageDriver.FindElement(byElement);
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }

            catch (Exception e)
            {
                log.Warn(e.StackTrace);
                log.Error(e.Message);
            }
            log.Info("After waitForElement::" + byElement);
            return element;
        }


        public IList<IWebElement> waitForElements(By byElement)
        {

            IList<IWebElement> elements = new List<IWebElement>();
            try
            {
                elements = pageDriver.FindElements(byElement);
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(byElement));
            }
            catch (WebDriverException e)
            {
                log.Warn(e.StackTrace);
                log.Error(e.Message);
            }
            return elements;
        }

        public void scrollToElement(IWebElement webelement)
        {
            Actions actions = new Actions(pageDriver);
            actions.MoveToElement(webelement);
            actions.Perform();

            IJavaScriptExecutor jse = (IJavaScriptExecutor)pageDriver;
            jse.ExecuteScript("window.scrollBy(0,-100)", "");

        }

        public void moveToElement(IWebElement webelement)
        {
            try
            {
                Actions actions = new Actions(pageDriver);
                actions.MoveToElement(webelement);
                actions.Perform();
            }
            catch (Exception e)
            {
                log.Warn(e.StackTrace);
                log.Error(e.Message);
            }
        }

        public void scrollUp(IWebElement webelement)
        {
            Actions actions = new Actions(pageDriver);
            actions.MoveToElement(webelement);
            actions.Perform();

            IJavaScriptExecutor jse = (IJavaScriptExecutor)pageDriver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
        }

        public void windowScrollUp(IWebElement webelement)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)pageDriver;
            jse.ExecuteScript("window.scrollBy(0,-250)", "");
            Actions actions = new Actions(pageDriver);
            actions.MoveToElement(webelement);
            actions.Perform();
        }
        public void waitForLoading()
        {
            int tme = 0;
            try
            {
               IWebElement  ele1 = pageDriver.FindElement(PageLoad);
                if (ele1 != null)
                {
                    tme = 0;
                    while (ele1.Displayed)
                    {
                        //Wait.waitFor(2);
                        tme += 2;
                    }
                }
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
            }
        }

        public void waitByTime(int time)
        {
            try
            {
                Thread.Sleep(time);
            }
            catch (ThreadInterruptedException e)
            {
                log.Warn(e.StackTrace);
                log.Error(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public void buttonClick(IWebElement elem)
        {
            try
            {
                log.Info("Before in buttonClick ::" + elem);
                elem.Click();
                log.Info("After in buttonClick ::" + elem);
            }
            catch (Exception e)
            {
                log.Warn("Exception in buttonClick ::" + elem);
                log.Warn(e.StackTrace);
                log.Error(e.Message);
                Console.WriteLine(e.StackTrace);
            
            }
        }



        public void submitButton(IWebElement elem)
        {
            try
            {
                log.Info("Before in submitButton ::" + elem);
                elem.Submit();
                log.Info("After in submitButton ::" + elem);
            }
            catch (Exception e)
            {
              
                log.Warn("Exception in submitButton ::" + elem);
                log.Warn(e.StackTrace);
                log.Error(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public void buttonClickJS(IWebElement elem)
        {
            try
            {
                log.Info("Before in buttonClickJS ::" + elem);
                //            webDriverWait.until(ExpectedConditions.elementToBeClickable(elem));
            }
            catch (Exception e)
            {
                
                log.Warn("Exception in buttonClickJS ::" + elem);
                log.Warn(e.StackTrace);
                log.Error(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            IJavaScriptExecutor js = (IJavaScriptExecutor)pageDriver;
            js.ExecuteScript("arguments[0].click()", elem);
            log.Info("After in buttonClickJS ::" + elem);
        }



        public void enterText(IWebElement webElement, String text)
        {
            try
            {
                log.Debug("Before enterText::" + webElement + ", with text::" + text);                
                webElement.SendKeys(text);
                log.Debug("After enterText::" + webElement + ", with text::" + text);
            }
            catch (Exception e)
            {
                log.Info(e.Message);
            }
        }

        

        public void clearText(IWebElement webElement)
        {
            try
            {
                log.Debug("Before clearText::" + webElement);
                webElement.Clear();
                log.Debug("After clearText::" + webElement);
            }
            catch (Exception e)
            {
                 log.Info(e.Message);
            }
        }

        public void clearAndEnterText(IWebElement webElement, String text)
        {
            try
            {
                log.Debug("Before clearAndEnterText::" + webElement + ", with text::" + text);
                //        IWebElement webElementEnter = waitForElement(webElement);
                webElement.Clear();
                webElement.SendKeys(text);
                log.Debug("After clearAndEnterText::" + webElement + ", with text::" + text);
            }
            catch (Exception e)
            {
                 log.Info(e.Message);
            }
        }

     
        public void appendText(By webElement, String text)
        {
            log.Debug("Before appendText::" + webElement + ", with text::" + text);
            IWebElement webElementEnter = waitForElement(webElement);
            webElementEnter.SendKeys(Keys.End + text);
            log.Debug("After appendText::" + webElement + ", with text::" + text);
        }

       

        public void selectOption(IWebElement webElement, String opt)
        {
            try
            {
                log.Debug("Before selectOption::" + webElement + ", selected with option::" + opt);
                SelectElement select = new SelectElement(webElement);
                select.SelectByText(opt);
                               log.Debug("After selectOption::" + webElement + ", selected with option::" + opt);
            }
            catch (Exception e)
            {
                 log.Info(e.Message);
            }
        }

        public void selectValue(IWebElement webElement, String text)
        {
            try
            {
                log.Debug("Before selectValue::" + webElement + ", selected with value::" + text);
                SelectElement select = new SelectElement(webElement);
                select.SelectByValue(text);
                log.Debug("After selectValue::" + webElement + ", selected with value::" + text);
            }
            catch (Exception e)
            {
                 log.Info(e.Message);
            }
        }

        public void selectOptionByIndex(IWebElement webElement, int index)
        {
            try
            {
                log.Debug("Before selectOptionByIndex::" + webElement + ", selected with index::" + index);
                SelectElement select = new SelectElement(webElement);
                select.SelectByIndex(index);
                log.Debug("After selectOptionByIndex::" + webElement + ", selected with index::" + index);
            }
            catch (Exception e)
            {
                 log.Info(e.Message);
            }
        }

       


    }
}
