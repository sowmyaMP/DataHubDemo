namespace DataHubDemo.Pages.Modules.Product
{
    using System;
    using DataHubDemo.Configuration;
    using Domain.Datahub;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;

    public class ProductManagePage 
    {
        [FindsBy(How = How.XPath, Using = ".//*[@id='dtProductListDescription3']")]
        private IWebElement productListDescription;

        [FindsBy(How = How.XPath, Using = ".//*[@id='dtProductList']/tbody/tr[1]/td[3]")]
        private IWebElement productFirstListRecord;

        public bool SearchProduct(string productDescription)
        {
            Wait.WaitForPageLoad();
            this.productListDescription.SendKeys(productDescription);
            Wait.WaitForPageLoad();
            try
            {
                if (this.productFirstListRecord.Displayed)
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
                return true;
            }
        }
    }
}
