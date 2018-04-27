namespace DataHubDemo.Pages.Modules.Product
{
    using System;
    
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class ProductCreatePage 
    {
        private string productName ;

        [FindsBy(How = How.Id, Using = "txtProductDescription")]
        private IWebElement productDesc;

        [FindsBy(How = How.Id, Using = "txtProductDescription")]
        private IWebElement saveButton;

        [FindsBy(How = How.Id, Using = "ddlIndustry")]
        private IWebElement productIndustry;

        [FindsBy(How = How.Id, Using = "ddlPackagingLevel")]
        private IWebElement packagingLevel;

        [FindsBy(How = How.Id, Using = "txtSKU")]
        private IWebElement sku;

        [FindsBy(How = How.Id, Using = "txtBrandName")]
        private IWebElement brandName;

        [FindsBy(How = How.Id, Using = "btnAutoAssign")]
        private IWebElement assignGTIN;

        [FindsBy(How = How.Id, Using = "ddlStatus")]
        private IWebElement status;

        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement save;

        [FindsBy(How = How.XPath, Using = "//button[contains(@id,'btnCancel')]")]
        private IWebElement cancel;

        [FindsBy(How = How.Id, Using = "btnCancel")]
        private IWebElement cancelButton;

        [FindsBy(How = How.Id, Using = "txtProductDescription")]
        private IWebElement continueCancelChanges;

        public string CreateProduct()
        {
            this.productName = "ProductAutomation" + RandomTimeStamp();
            this.productDesc.SendKeys(this.productName);
            this.brandName.SendKeys("BrandAutomation" + RandomTimeStamp());
            this.SelectIndustry();
            this.SelectSupplyChain();
            this.save.Click();
            return this.productName;
        }

        public string CreateProductInUse(string productIndustry, string packagingLevel)
        {
            throw new NotImplementedException();
        }

        public string CreateProductInDraft(string productIndustry, string packagingLevel)
        {
            throw new NotImplementedException();
        }

        private static string RandomTimeStamp()
        {
            var now = DateTime.Now;
            var str = now.ToString("yyyyMMddHHmmss");
            return str;
        }

        private void SelectIndustry()
        {
            SelectElement selectindustry = new SelectElement(this.productIndustry);
            selectindustry.SelectByValue("2");
        }

        private void SelectSupplyChain()
        {
            SelectElement selectsupplychain = new SelectElement(this.packagingLevel);
            selectsupplychain.SelectByValue("1");
        }
    }
}
