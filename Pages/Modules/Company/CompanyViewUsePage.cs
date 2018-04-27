namespace DataHubDemo.Pages.Modules.Company
{

    using System;
    using DataHubDemo.Configuration;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    public class CompanyViewUsePage 
    {
        private string resultCount;

        [FindsBy(How = How.XPath, Using = ".//*[@id='companyTabs']/li[1]/a")]
        private IWebElement searchByCompanyTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='SearchResultsTable']/tbody/tr[1]/td[4]")]
        private IWebElement companyFirstListRecord;


        [FindsBy(How = How.XPath, Using = ".//*[@id='txtCompanyName']")]
        private IWebElement txtCompanyName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtStreetAddress']")]
        private IWebElement txtStreetAddress;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtCity']")]
        private IWebElement txtCity;

        [FindsBy(How = How.XPath, Using = ".//*[@id='SearchResultsTableCompany3']")]
        private IWebElement txtSearchForCompanyInDatatable;

        [FindsBy(How = How.XPath, Using = ".//*[@id='SearchResultsTablePrefixStatus4']")]
        private IWebElement txtSearchForStatusInDatatable;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtZipCode']")]
        private IWebElement txtZipPostalCode;

        [FindsBy(How = How.XPath, Using = ".//*[@id='btnApplyFilters']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='panel-Company']/div/form/div[3]/div[3]/input")]
        private IWebElement exactMatchOnlyCheckbox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='companyTabs']/li[2]/a")]
        private IWebElement searchByPrefixTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtPrefix']")]
        private IWebElement txtPrefix;

        [FindsBy(How = How.XPath, Using = ".//*[@id='companyTabs']/li[3]/a")]
        private IWebElement searchByGTINTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtGTN']")]
        private IWebElement txtGTN;

        [FindsBy(How = How.XPath, Using = ".//*[@id='companyTabs']/li[4]/a")]
        private IWebElement searchByGLNTab;

        [FindsBy(How = How.XPath, Using = ".//*[@id='txtGLN']")]
        private IWebElement txtGLN;

        [FindsBy(How = How.XPath, Using = ".//*[@id='SearchResultsTable_info']")]
        private IWebElement txtSearchResultTableinfo;

        
        public bool SearchByCompanyName(string companyName, string StreetAddress, string city, string zip)
        { int constant = 0;
            
            
            try
            {
                Wait.WaitForPageLoad();
                if (!String.IsNullOrEmpty(companyName))
                {
                    txtCompanyName.SendKeys(companyName);
                    constant = 1;

                }
                else
                {
                    return false;
                }
                if (!String.IsNullOrEmpty(StreetAddress))
                {
                    txtStreetAddress.SendKeys(StreetAddress);
                    constant = 1;
                }
                if (!String.IsNullOrEmpty(city))
                {
                    txtCity.SendKeys(city);
                    constant = 1;
                }
                if (!String.IsNullOrEmpty(zip))
                {
                    txtZipPostalCode.SendKeys(zip);
                    constant = 1;
                }

                if (constant == 1) { return true; }
                else { return false; }
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        
        public bool SearchByGLN(string gLN)
        {
            try
            {
                if (!String.IsNullOrEmpty(gLN))
                {
                    txtGLN.SendKeys(gLN);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
            
        }

        public bool SearchByGTIN(string gTIN)
        {
            try
            {
                 if (!String.IsNullOrEmpty(gTIN)) {
                    txtGTN.SendKeys(gTIN);
                }
                return true;
            }
            catch (Exception)
            {
                return false;                
            }
        }

        public string ReturnSearchResultCompanyInDatatable()
        {           
               try
                {
                Wait.WaitForPageLoad();
                string countRecord = txtSearchResultTableinfo.Text;
                if (countRecord.Contains("Showing "))
                {
                    int pFrom = countRecord.IndexOf("of ") + "of ".Length;
                    int pTo = countRecord.LastIndexOf(" entries ");

                    String resultCount = countRecord.Substring(pFrom, pTo - pFrom);
                    
                }
                return resultCount.Trim();
                
               }
                catch (Exception)
                {
                    return resultCount;
                }
            }
        
        public bool CheckStatusOfSearchButton()
        {
            return searchButton.Enabled;
        }

        public bool OpenSearchByCompanyTab()
        {
            try
            {
                Wait.WaitForPageLoad();
                searchByCompanyTab.Click();
                Wait.WaitForPageLoad();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool OpenSearchByPrefixTab()
        {
        
           try
            {
                Wait.WaitForPageLoad();
                searchByPrefixTab.Click();
                Wait.WaitForPageLoad();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool OpenSearchByGLNTab()
        {
            try
            {
                Wait.WaitForPageLoad();
                searchByGLNTab.Click();
                Wait.WaitForPageLoad();
                //this.wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@text='Search by Company']")));

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool OpenSearchByGTINTab()
        {
            try
            {
                Wait.WaitForPageLoad();
                searchByGTINTab.Click();
                Wait.WaitForPageLoad();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ClickOnSearch()
        {
            if (searchButton.Enabled) {
                searchButton.Click();
                return true;
            }
            return false;
           
        }
        public bool SearchByPrefix(string prefix)
        {
            try
            {
                if (!String.IsNullOrEmpty(prefix))
                {
                    txtGTN.SendKeys(prefix);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SearchInDatatableByFilter(string companyName, string status)
        {
            Wait.WaitForPageLoad();
            if (!String.IsNullOrEmpty(companyName)) {

                Wait.WaitForPageLoad();
                txtSearchForCompanyInDatatable.SendKeys(companyName);
            }
            if (!String.IsNullOrEmpty(status)) {
                Wait.WaitForPageLoad();
                txtSearchForStatusInDatatable.SendKeys(status);
            }
                       
            Wait.WaitForPageLoad();
            try
            {
                if (!this.companyFirstListRecord.Text.Contains("No matching records found"))
                {
                    if (this.companyFirstListRecord.Displayed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
