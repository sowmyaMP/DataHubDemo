namespace DataHubDemo.Steps.Modules.Product
{
    using System;
    using DataHubDemo.Pages.Modules.Product;
      using DataHubDemo.Configuration;
    using Domain.Datahub;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductViewUseSteps
    {

     
      
        string strCompanyName = "Medical Devices R Us";
        public IWebDriver driver = Driver.Browser; 
        public String productNameCreated;
        public ProductViewUsePage objProductViewUsePage = new ProductViewUsePage(Driver.Browser);
        private Boolean status;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        

        [Given(@"a user login to datahub with company (.*)")]
        public void GivenAUserLoginToDatahubWithCompany(string p0)
        {
         
          objProductViewUsePage.selectCompnay(p0);
            log.Info("a user login to datahub with company" + p0);
            //Assert.IsFalse((strCompany == p0), "comnpany not found");

        }


        [Given(@"navigate to InUse")]
        public void GivenNavigateToInUse()
        {
            objProductViewUsePage.clickOnInuse();
        }



        [Given(@"serach the (.*) and select the product")]
        public void GivenSerachTheAndSelectTheProduct(string p0)
        {
            objProductViewUsePage.SearchAndSelectProductByGtin(p0);
        }


        [Given(@"Click on sharing tab and click AddButton")]
        public void GivenClickOnSharingTab()
        {
            objProductViewUsePage.ProductShareAndAdd();
        }




        [When(@"the user share the selected product with company (.*)")]
        public void WhenTheUserShareTheSelectedProductWithCompany(string p0)
        {
            objProductViewUsePage.SearchCompanyAndShareProduct(p0);
        }

        [Then(@"the product is shared with the selected company")]
        public void ThenTheProductIsSharedWithTheSelectedCompany()
        {
            Console.WriteLine("Happy Path");
        }

    }

}

