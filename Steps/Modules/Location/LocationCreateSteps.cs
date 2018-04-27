namespace DataHubDemo.Steps.Modules.Location
{

    using DataHubDemo.Pages;
      using DataHubDemo.Configuration;
    using Domain.Datahub;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using TechTalk.SpecFlow;
    using DataHubDemo.Pages.Common;
    using DataHubDemo.Pages.Modules.Location;

    [Binding]
    public class LocationCreateSteps
    {
        private IWebDriver driver = Driver.Browser;
        private IHome home ;
        private ILocationCreate locationCreate;
        private bool status;
        private ILocationManage locationManage;
        private string locationName;

        public LocationCreateSteps() {
            HomePage home = new HomePage(this.driver);
            LocationCreatePage locationCreate = new LocationCreatePage();
            PageFactory.InitElements(driver, this.locationCreate);
            LocationManagePage locationManage = new LocationManagePage();
            PageFactory.InitElements(driver, this.locationManage);
        }

        [Given(@"navigate to location create page")]
        public void GivenNavigateToLocationCreatePage()
        {
            this.home.OpenLocationCreateLink();
        }

        [When(@"enter location mandatory details")]
        public void WhenEnterLocationMandatoryDetails()
        {
            FeatureContext.Current["LocationNameCreated"] = this.locationCreate.CreateLocationWithInvalidAddress();
        }

        [Given(@"navigate to location manage")]
        public void GivenNavigateToLocationManage()
        {
            this.home.OpenLocationManageLink();
        }

        [When(@"enter search location in datatable")]
        public void WhenEnterSearchLocationInDatatable()
        {
            this.locationName = (string)FeatureContext.Current["LocationNameCreated"];
            this.status = this.locationManage.SearchLocation(this.locationName);
        }

        [Then(@"location is displayed successfully")]
        public void ThenLocationIsDisplayedSuccessfully()
        {
            Assert.IsTrue(this.status);
        }
    }
}
