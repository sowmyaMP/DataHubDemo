namespace DataHubDemo.Pages.Common
{
    using System;
    using DataHubDemo.Configuration;
    
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class HomePage 
    {
        [FindsBy(How = How.XPath, Using = ".//*[@id='navbar-collapse-example']/ul/li[1]/a")]
        private IWebElement homeLink;

        [FindsBy(How = How.XPath, Using = ".//*[@id='home']")]
        private IWebElement homeButton;

        [FindsBy(How = How.Id, Using = "txtProductDescription")]
        private IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = ".//li/a[contains(@href,'/Admin/Home')]")]
        private IWebElement administration;

        [FindsBy(How = How.XPath, Using = ".//a[contains(text(),'Location)']")]
        private IWebElement location;

        [FindsBy(How = How.XPath, Using = ".//a[contains(text(),'Company)']")]
        private IWebElement company;

        [FindsBy(How = How.XPath, Using = ".//li[contains(@class,'yamm-fw dropdown')]/a[contains(text(),'Product')]")]
        private IWebElement productModuleLink;

        [FindsBy(How = How.XPath, Using = ".//li[contains(@class,'yamm-fw dropdown')]/a[contains(text(),'Location')]")]
        private IWebElement locationModuleLink;

        [FindsBy(How = How.XPath, Using = ".//li[contains(@class,'yamm-fw dropdown')]/a[contains(text(),'Company')]")]
        private IWebElement companyModuleLink;

        [FindsBy(How = How.XPath, Using = ".//li[contains(@class,'yamm-fw dropdown')]/a[contains(text(),'Reports')]")]
        private IWebElement reportModuleLink;

        private WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = ".//*[contains(text(),'Reports')]")]
        private IWebElement reports;

        [FindsBy(How = How.XPath, Using = ".//*[contains(@class,'yamm-fw')and contains(@data-toggle,'dropdown')]/a")]
        private IWebElement webeLEMENT;

        [FindsBy(How = How.XPath, Using = ".//li/a[contains(@href,'/Product/Detail/AddNewProduct')]")]
        private IWebElement productCreatelink;

        [FindsBy(How = How.XPath, Using = ".//li/a[contains(@href,'/Product/Home')]")]
        private IWebElement productManageLink;

        [FindsBy(How = How.XPath, Using = ".//li/a[contains(@href,'/Company/ViewUse')]")]
        private IWebElement companyViewUseLink;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navbar-collapse-example']/ul/li[3]/ul/li[1]/a")]
        private IWebElement locationCreateLink;

        [FindsBy(How = How.XPath, Using = ".//*[@id='navbar-collapse-example']/ul/li[3]/ul/li[2]/a")]
        private IWebElement locationManageLink;

        public HomePage(IWebDriver driver)
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        public void OpenAdminPage()
        {
            try { this.OpenLink(this.administration); }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        public void OpenCompanyViewUselink()
        {
            try
            {
                Wait.WaitForPageLoad();
                this.wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(".//*[@id='home']")));
                this.OpenCompanyModal();
                this.OpenLink(this.companyViewUseLink);
                Wait.WaitForPageLoad();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        public void OpenProductCreatelink()
        {
            try
            {
                Wait.WaitForPageLoad();
                this.Modulelink(this.productModuleLink, this.productCreatelink);
            }
            catch (Exception e)
            {// e.printStackTrace();
                e.ToString();
            }
        }

        public void OpenProductManagelink()
        {
            Wait.WaitForPageLoad();
            this.Modulelink(this.productModuleLink, this.productManageLink);
        }

        public void OpenLocationCreateLink()
        {
            Wait.WaitForPageLoad();
            this.Modulelink(this.locationModuleLink, this.locationCreateLink);
        }

        public void OpenLocationManageLink()
        {
            Wait.WaitForPageLoad();
            this.Modulelink(this.locationModuleLink, this.locationManageLink);
        }

        public void NavigateToHomeLink()
        {
            Wait.WaitForPageLoad();
            this.OpenLink(this.homeLink);
        }

        public void OpenProductViewUse()
        {
            throw new NotImplementedException();

        }

        public void OpenLocationViewUseLink()
        {
            throw new NotImplementedException();
        }

        public void OpenReportsLink()
        {
            throw new NotImplementedException();
        }

        private void OpenLink(IWebElement element)
        {
            try
            {
                this.wait.Until(ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        private void OpenReportModal()
        {
            try
            {
                this.OpenLink(this.reportModuleLink);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        private void OpenLocationModal()
        {
            try
            {
                this.OpenLink(this.locationModuleLink);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        private void OpenCompanyModal()
        {
            try
            {
                this.OpenLink(this.companyModuleLink);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        private void Modulelink(IWebElement module, IWebElement element)
        {
            try
            {
                Wait.WaitForPageLoad();
                this.OpenLink(module);
                this.OpenLink(element);
                Wait.WaitForPageLoad();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

    }
}
