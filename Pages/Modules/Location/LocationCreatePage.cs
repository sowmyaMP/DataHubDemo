namespace DataHubDemo.Pages.Modules.Location
{
    using System;
     using DataHubDemo.Configuration;
    using Domain.Datahub;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class LocationCreatePage 
    {
        private string locationAutomationWithoutAddress = null;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Name']")]
        private IWebElement locationNameField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Name2']")]
        private IWebElement locationName2Field;

        [FindsBy(How = How.XPath, Using = ".//*[@id='IndustryID']")]
        private IWebElement industryDropdown;

        [FindsBy(How = How.XPath, Using = ".//*[@id='frmLocation']/div[3]/div[1]/div/div[1]")]
        private IWebElement parentField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='frmLocation']/div[3]/div[1]/div/div[2]/button")]
        private IWebElement parentFieldIcon;

        [FindsBy(How = How.XPath, Using = ".//*[@id='LocationDetailEligibleParentDataTable']/tbody/tr[1]/td[1]")]
        private IWebElement parentGLNDataTableSelect;

        [FindsBy(How = How.XPath, Using = ".//*[@id='frmLocation']/div[3]/div[1]/div/div[2]/button")]
        private IWebElement parentGLNSelectionModalCancel;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnParentGLNSelectionHead']")]
        private IWebElement setParentGLN;

        [FindsBy(How = How.XPath, Using = ".//*[@id='frmLocation']/div[4]/div[2]")]
        private IWebElement supplyChainRoleDropdown;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_ManuallyAssignGLN']")]
        private IWebElement manuallyAssignGLNCheckBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Address_AddressLine1']")]
        private IWebElement addressLine1Field;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Address_AddressLine2']")]
        private IWebElement addressLine2Field;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Address_AddressLine3']")]
        private IWebElement addressLine3Field;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Address_City']")]
        private IWebElement cityField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Address_StateList']")]
        private IWebElement stateDropdown;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Address_Zip']")]
        private IWebElement zIPField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Address_CountryList']")]
        private IWebElement countryDropdown;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Location_Address_Phone']")]
        private IWebElement phoneField;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnSaveLocation']")]
        private IWebElement saveLocation;

        public string CreateLocationWithInvalidAddress()
        {
            string locationName = this.EnterLocationWithoutAddress();
            this.EnterDefaultAddress();
            this.saveLocation.Click();
            return locationName;
        }

         public void CreateLocationWithValidAddress()
        {
        }

        public void CreateLocationWithRandomAddress()
        {
        }

        public void EnterAddress(string addressLine1, string addressline2)
        {
            Driver.Browser.FindElementOnPage(By.XPath(".//*[@id='Location_Address_AddressLine1']"));
            this.addressLine1Field.SendKeys(addressLine1);
            this.addressLine2Field.SendKeys(addressline2);
            this.addressLine3Field.SendKeys(this.RandomTimeStamp());
            this.EnterDefaultCityAndCountyDetails();
        }

        public void EnterDefaultCityAndCountyDetails()
        {
            this.cityField.SendKeys("CALABASH");
            SelectElement selectElementFromState = new SelectElement(this.stateDropdown);
            selectElementFromState.SelectByValue("40");
            this.zIPField.SendKeys("284672755");
            SelectElement selectElementFromCountry = new SelectElement(this.countryDropdown);
            selectElementFromCountry.SelectByValue("224");
            this.phoneField.SendKeys("(910) 579-8222");
        }

        public void EnterDefaultAddress() {
            Driver.Browser.FindElementOnPage(By.XPath(".//*[@id='Location_Address_AddressLine1']"));
            this.addressLine1Field.SendKeys("HARBOR COURT BLDG");
            this.addressLine2Field.SendKeys("9970 BEACH ");
            this.addressLine3Field.SendKeys(this.RandomTimeStamp());
            this.EnterDefaultCityAndCountyDetails();
        }

        public string EnterLocationWithoutAddress()
        {
            this.locationAutomationWithoutAddress = "LocAutomation" + this.RandomTimeStamp();
            this.locationNameField.SendKeys(this.locationAutomationWithoutAddress);
            this.locationName2Field.SendKeys(this.locationAutomationWithoutAddress);
            this.parentFieldIcon.Click();
            Wait.WaitForPageLoad();
            if (this.parentGLNDataTableSelect.Displayed)
            {
                this.parentGLNDataTableSelect.Click();
                if (!this.parentGLNDataTableSelect.Enabled)
                {
                    this.parentGLNDataTableSelect.Click();
                }
                else
                {
                    this.setParentGLN.Click();
                }
            }

            return this.locationAutomationWithoutAddress;
        }

        private string RandomTimeStamp() {
            var now = DateTime.Now;
            var randomNumberWithTime = now.ToString("yyyyMMddHHmmss");
            return randomNumberWithTime;
        }
    }
}
