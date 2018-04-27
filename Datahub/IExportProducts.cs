namespace Domain.Datahub
{
   public interface IExportProducts
    {

        string WhenUserClicksOnExportAllProductsFromTable();

        void WhenUserClickOnContinueButton();

        void WhenUserOpensTheExportedFile();

       void ThenExportConfirmationPopupIsDisplayed();

        void ThenGreenColourConfirmationBoxIsDisplayed();

        string ThenNotificationCountIsIncrementedBy(int x);

        void ThenExportCentreIsDisplayedWithExportedDateAsCurrentDate();

        void ThenExportedStatusIsCompleted();

        void ThenExportedFileIsPresent();

        void ThenSelectedProductsArePresentInTheExportedFile();

    }
}
