namespace DataHubDemo.Pages.Modules.Location
{
    using System;
    using DataHubDemo.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class LocationManagePage 
    {
        [FindsBy(How = How.XPath, Using = ".//*[@id='dtLocationListName3']")]
        private IWebElement locationListName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='dtLocationList']/tbody/tr[1]/td[3]")]
        private IWebElement locationList;

        public bool SearchLocation(string locationDescription)
        {
            Wait.WaitForPageLoad();
            this.locationListName.SendKeys(locationDescription);
            Wait.WaitForPageLoad();
            try
            {
                if (this.locationList.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
