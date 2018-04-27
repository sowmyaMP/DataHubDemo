using System;
using TechTalk.SpecFlow;

namespace DataHubDemo.Steps.Modules.Product
{
    [Binding]
    public class ExportProductsSteps 
    {
        [When(@"user clicks on Export All Products from table")]
        public void WhenUserClicksOnExportAllProductsFromTable()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user click on Continue button")]
        public void WhenUserClickOnContinueButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user opens the Exported file")]
        public void WhenUserOpensTheExportedFile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Export confirmation popup is displayed")]
        public void ThenExportConfirmationPopupIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Green colour confirmation box is displayed")]
        public void ThenGreenColourConfirmationBoxIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Notification count is incremented by (.*)")]
        public void ThenNotificationCountIsIncrementedBy(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Export centre is displayed with Exported date as current date")]
        public void ThenExportCentreIsDisplayedWithExportedDateAsCurrentDate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Exported status is Completed")]
        public void ThenExportedStatusIsCompleted()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Exported file is present")]
        public void ThenExportedFileIsPresent()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"selected products are present in the exported file")]
        public void ThenSelectedProductsArePresentInTheExportedFile()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
