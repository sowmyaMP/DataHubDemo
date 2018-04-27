namespace DataHubDemo.Configuration
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using TechTalk.SpecFlow;
    using DataHubDemo.Pages.Main;
    using System.Collections.Generic;

    [Binding]
    public  sealed  class Startup :BasePage
    {
        private static IWebDriver chromeDriver = null;
        private static string path = null;
        private static string resultPath = null;
        private IWebDriver driver;
        public Startup(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

        }

        [BeforeFeature()]
        public static void BeforeFeature(string chrome)
        {
            try
            {

                string str= chrome;
                var options = new ChromeOptions();
                options.AddArguments("test-type");
                options.ToCapabilities();
                path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                if (path.Contains("Solutions"))
                {
                    int index = path.IndexOf("Solutions");
                    resultPath = path.Substring(0, index+10);
                }

                ChromeDriverService service = ChromeDriverService.CreateDefaultService(resultPath + "AutomatedTestSolutions\\DataHubDemo\\DriverSet\\");
                chromeDriver = new ChromeDriver(service, options);
                if (chromeDriver != null)
                {
                    FeatureContext.Current.Add("Chrome", chromeDriver);
                    Driver.Browser = chromeDriver;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw;
            }
        }

        public  static void ApplicationVariables()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            Console.WriteLine(path);
            path = path + "\\TestVariables\\ApplicatonVariables\\ApplicationDataHubVariables.csv";

            using (var reader = new StreamReader(path))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }

        }
        

        [BeforeFeature("Datahub-Stage")]
        public static  void AddTheStageUrl()
        {

            //getURL("https://dh.stage.gs1us.org");
            Driver.Browser.Url = "https://dh.stage.gs1us.org";
        }

        public static void GetEnviornmentVariable(string broswer,string environment)
        {



        }

        [BeforeFeature("Datahub-QA")]
        public static void AddTheQAUrl()
        {
            try
            {
                Driver.Browser.Url = "https://dh.qa.gs1us.org";
                Driver.Browser.FindElement(By.Id("UserName")).SendKeys("bdash@gs1us.org");
                Driver.Browser.FindElement(By.Id("Password")).SendKeys("Iceage@7");
                Driver.Browser.FindElement(By.XPath(".//*[@id='main-section']/div/form/fieldset/div[2]/div[1]/input")).Click();
                Driver.Browser.SwitchTo().Alert().Accept();
            }
            catch (Exception)
            {
            }
        }

        [BeforeFeature("Admin")]
        public static void AddAdminDetails()
        {
            try
            {
                Driver.Browser.FindElement(By.Id("UserName")).SendKeys("gs1ustestuser+admin@gmail.com");
                Driver.Browser.FindElement(By.Id("Password")).SendKeys("Testing123");
                Driver.Browser.FindElement(By.XPath(".//*[@id='main-section']/div/form/fieldset/div[2]/div[1]/input")).Click();
                Driver.Browser.SwitchTo().Alert().Accept();
            }
            catch (Exception)
            {
            }
        }

        [BeforeFeature("Admin-QA")]
        public static void AddAdminQADetails()
        {
            try
            {
                Driver.Browser.FindElement(By.Id("UserName")).SendKeys("bdash@gs1us.org");
                Driver.Browser.FindElement(By.Id("Password")).SendKeys("Iceage@7");
                Driver.Browser.FindElement(By.XPath(".//*[@id='main-section']/div/form/fieldset/div[2]/div[1]/input")).Click();
                Driver.Browser.SwitchTo().Alert().Accept();
            }
            catch (Exception)
            {
            }
        }

        [BeforeFeature("GS1USEnterprise1")]
        public static void Gs1Enterprise()
        {
            try
            {
                Wait.CheckForElementExistance(Driver.Browser, By.Id("SelectedCompanyId"));

                IWebElement dropdown = Driver.Browser.FindElement(By.Id("SelectedCompanyId"));
                SelectElement selectDropdown = new SelectElement(dropdown);
                selectDropdown.SelectByValue("275340");
                Driver.Browser.FindElement(By.XPath(".//*[@id='main-section']/div/form/fieldset/div[3]/div[1]/input")).Click();
            }
            catch (Exception)
            {
            }
        }

        [AfterFeature("Chrome")]
        public static void AfterScenarioFeature()
        {
            var value = FeatureContext.Current.Get<IWebDriver>("Chrome");
            value.Dispose();
        }
    }
}
