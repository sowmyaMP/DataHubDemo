namespace DataHubDemo.Steps.Modules.Product
{
    using DataHubDemo.Configuration;
   
    using DataHubDemo.Pages.Common;
    using DataHubDemo.Pages.Modules.Product;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductCreateSteps
    {
        private string productNameCreated;
        private IWebDriver driver = Driver.Browser;
         private HomePage home;
        ProductCreatePage productCreate;
         ProductManagePage productManage;
        private bool status;

        public ProductCreateSteps() {
             home = new HomePage(this.driver);
             productCreate = new ProductCreatePage();
            PageFactory.InitElements(driver, productCreate);
             productManage = new ProductManagePage();
            PageFactory.InitElements(driver, productManage);
        }


      [Given(@"the user navigate to Home page")]
        public void GivenTheUserNavigateToHomePage()
        {
            if (this.driver != null)
            {
                home.NavigateToHomeLink();
            }
        }
        
        [Given(@"the user navigate to Product create page")]
        public void GivenTheUsernavigateToProductCreatePage()
        {
            home.OpenProductCreatelink();
        }

        [When(@"enter product mandatory details")]
        public void WhenEnterProductMandatoryDetails()
        {
            FeatureContext.Current["productNameCreated"] = this.productCreate.CreateProduct();
        }

        [Given(@"navigate to product manage")]
        public void GivenNavigateToProductManage()
        {
          home.OpenProductManagelink();
        }


        [When(@"enter search product in datatable")]
        public void WhenEnterSearchProductInDatatable()
        {
           string name = (string)FeatureContext.Current["productNameCreated"];
           this.status = this.productManage.SearchProduct(name);
        }

        [Then(@"product is displayed successfully")]
        public void ThenProductIsDisplayedSuccessfully()
        {
            Assert.IsTrue(this.status);
        }

        [When(@"save the product")]
        public void WhenSaveTheProduct()
        {
        }

        [Then(@"the result should show created successfully")]
        public void ThenTheResultShouldShowCreatedSuccessfully()
        {
        }

        [When(@"create productname with bname")]
        public void ProductnameWithBname()
        {
        } 
    }

    
}
