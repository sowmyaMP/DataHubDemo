namespace DataHubDemo.Steps.Modules.Company
{
    using DataHubDemo.Pages;
      using DataHubDemo.Configuration;
    using Domain.Datahub;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using TechTalk.SpecFlow;
    using DataHubDemo.Pages.Modules.Company;
    using DataHubDemo.Pages.Common;

    [Binding]
    public class CompanyViewUseSteps
    {
        private IWebDriver driver = Driver.Browser;
        private IHome home;
      
        private bool status;
        CompanyViewUsePage objCompanyViewUse;
        public CompanyViewUseSteps()
        {
            HomePage home = new HomePage(this.driver);
            objCompanyViewUse = new CompanyViewUsePage();
            PageFactory.InitElements(driver, objCompanyViewUse);
        }

        [Given(@"the user navigate to Company view/use")]
        public void GivenNavigateToCompanyViewUse()
        {
            this.home.OpenCompanyViewUselink();

        }


        [When(@"search button of Company Veiw Use is (.*)")]
        public void WhenCheckSearchButtonOfCompanyVeiwUseIsInactive(string status)
        {
            if (status.ToLower().Contains("inactive"))
            {
                Assert.Equals(false, objCompanyViewUse.CheckStatusOfSearchButton());
            }
            else if (status.ToLower().Contains("active"))
            {
                Assert.Equals(true, objCompanyViewUse.CheckStatusOfSearchButton());
            }
            else
            {
                Assert.Fail();
            }
        }

        [When(@"user click on next button")]
        public void WhenUserClickOnNextButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Dashboard Panel is displayed")]
        public void ThenDashboardPanelIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"user click on Export centre icon")]
        public void WhenUserClickOnExportCentreIcon()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"export center page displayed")]
        public void ThenExportCenterPageDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"select the Company tab")]
        public void GivenSelectTheCompanyTab()
        {
            objCompanyViewUse.OpenSearchByCompanyTab();
        }

        [Given(@"provide the company name as '(.*)'")]
        public void GivenProvideTheCompanyNameAs(string companyName)
        {
            objCompanyViewUse.SearchByCompanyName(companyName, null, null, null);
        }

        [When(@"user clicks on search button")]
        public void WhenUserClicksOnSearchButton()
        {
            objCompanyViewUse.ClickOnSearch();
        }

        [Then(@"search result contains more than (.*) records")]
        public void ThenSearchResultContainsMoreThanRecords(int countOfRecord)
        {
            Assert.IsTrue(countOfRecord.Equals(objCompanyViewUse.ReturnSearchResultCompanyInDatatable()));
        }

        [Then(@"active records are displayed in black colour text")]
        public void ThenActiveRecordsAreDisplayedInBlackColourText()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"inactive records are displayed in red colour text")]
        public void ThenInactiveRecordsAreDisplayedInRedColourText()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"select the Prefix Origin as '(.*)'")]
        public void GivenSelectThePrefixOriginAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"search result contains (.*) records")]
        public void ThenSearchResultContainsRecords(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"select the Prefix tab")]
        public void GivenSelectThePrefixTab()
        {
            objCompanyViewUse.OpenSearchByPrefixTab();

        }

        [Given(@"provide the Prefix as '(.*)'")]
        public void GivenProvideThePrefixAs(int prefixNumber)
        {
            objCompanyViewUse.SearchByPrefix(prefixNumber.ToString());
        }

        [Then(@"search result contains the company (.*) and (.*)")]
        public void ThenSearchResultContainsTheCompany(string companyName,string status)
        {
            objCompanyViewUse.SearchInDatatableByFilter(companyName, status);

        }

        [Then(@"the company is inactive")]
        public void ThenTheCompanyIsInactive()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the company is active")]
        public void ThenTheCompanyIsActive()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"select the GTIN tab")]
        public void GivenSelectTheGTINTab()
        {
            objCompanyViewUse.OpenSearchByGTINTab();
        }

        [Given(@"provide the GTIN as '(.*)'")]
        public void GivenProvideTheGTINAs(int gTINNumber)
        {
            objCompanyViewUse.SearchByGTIN(gTINNumber.ToString());
        }

        [Given(@"select the GLN tab")]
        public void GivenSelectTheGLNTab()
        {
            objCompanyViewUse.OpenSearchByGLNTab();
        }

        [Given(@"provide the GLN as '(.*)'")]
        public void GivenProvideTheGLNAs(int gLNNumber)
        {
            objCompanyViewUse.SearchByGTIN(gLNNumber.ToString());
        }

        [When(@"the user navigate to Company Downloads options")]
        public void WhenTheUserNavigateToCompanyDownloadsOptions()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"'(.*)' download option is present with date created as current date")]
        public void ThenDownloadOptionIsPresentWithDateCreatedAsCurrentDate(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"'(.*)' download option is present with the First Day of Current Month")]
        public void ThenDownloadOptionIsPresentWithTheFirstDayOfCurrentMonth(string p0)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
