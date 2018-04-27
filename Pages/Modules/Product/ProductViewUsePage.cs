
namespace DataHubDemo.Pages.Modules.Product
{
    using System;
    using DataHubDemo.Configuration;
    using DataHubDemo.Pages.Main;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using System.Collections;
    using OpenQA.Selenium.Support.UI;

    public class ProductViewUsePage : BasePage
    {
        private IWebDriver driver;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductViewUsePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

        }
        public static readonly By productListDescription = By.XPath(".//*[@id='dtProductListDescription3']");
        public static readonly By productFirstListRecord = By.XPath(".//*[@id='dtProductList']/tbody/tr[1]/td[3]");
        public static readonly By selectedCompanyId = By.Id("SelectedCompanyId");
        public static readonly By signInWithCompany = By.XPath(".//*[@id='main-section']/div/form/fieldset/div[3]/div[1]/input");
        public static readonly By productInuse = By.XPath(".//li/a[contains(text(),'In Use')]");
        public static readonly By searchByGtin = By.XPath(".//*[@id='dtInUseProductListGTIN3']");
        public static readonly By clickOnPrduct = By.XPath(".//*[@id='dtInUseProductList']/tbody/tr/td[2]/a");
        public static readonly By sharignProductTab = By.XPath(".//*[@id='ProductdetailTabs']/li[4]/a");
        public static readonly By clickAddNewButton = By.XPath(".//*[@id='btnAddNew']");
        public static readonly By searchCompany = By.XPath(".//*[@id='dtShareEligibleCompaniesName1']");
        public static readonly By selectCompany = By.XPath(".//*[@id='dtShareEligibleCompanies']/tbody/tr/td[1]");
        public static readonly By clickContinue = By.XPath(".//*[@id='btnContinue']");
        public static readonly By confirmPopup = By.XPath(".//*[@id='saveConfirmModal']/div/div");


        public IWebElement getSelectCompany() { return waitForElement(selectedCompanyId); }
        public IWebElement getSignInWithCompany() { return waitForElement(signInWithCompany); }
        public IWebElement getproductInuse() { return waitForElement(productInuse);}
        public IWebElement getsearchByGtin() { return waitForElement(searchByGtin); }
        public IWebElement getclickOnPrduct() { return waitForElement(clickOnPrduct); }

        public IWebElement getsharignProductTab() { return waitForElement(sharignProductTab); }
        public IWebElement getclickAddNewButton() { return waitForElement(clickAddNewButton); }
        public IWebElement getsearchCompany() { return waitForElement(searchCompany); }
        public IWebElement getselectCompany() { return waitForElement(selectCompany); }
        public IWebElement getclickContinue() { return waitForElement(clickContinue); }
        public IWebElement getconfirmPopup() { return waitForElement(confirmPopup); }

        public void selectCompnay(string companyName)
        {
            log.Info(" Select company " + selectCompany);
            selectOption(getSelectCompany(), companyName);
            buttonClick(getSignInWithCompany());           
            WaitForPageLoad();
           

        }
        //*[@id="ui-tab-495"]
        public void clickOnInuse()
        {
            
            WaitForPageLoad();
            buttonClick(getproductInuse());
            WaitForPageLoad();    

        }

        public void SearchAndSelectProductByGtin(string strGtin)
        {
            WaitForPageLoad();
            enterText(getsearchByGtin(), strGtin);           
            WaitForPageLoad();
            buttonClick(getclickOnPrduct());
           
        }

        public void  ProductShareAndAdd()
        {
            WaitForPageLoad();
            buttonClick(getsharignProductTab());
            buttonClick(getclickAddNewButton());
        }


        public void SearchCompanyAndShareProduct(string strCompany)
        {
            WaitForPageLoad();
            enterText(getsearchCompany(), strCompany);
            WaitForPageLoad();
            buttonClick(getselectCompany());
            buttonClick(getclickContinue());
              buttonClick(getconfirmPopup());
            

        }
    }
}
