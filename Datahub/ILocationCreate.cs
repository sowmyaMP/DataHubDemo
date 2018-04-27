namespace Domain.Datahub
{
    public interface ILocationCreate
    {
        string CreateLocationWithInvalidAddress();

        void CreateLocationWithValidAddress();

        void CreateLocationWithRandomAddress();

        void EnterAddress(string addressLine1, string addressline2);

        void EnterDefaultCityAndCountyDetails();

        void EnterDefaultAddress();

        string EnterLocationWithoutAddress();
    }
}
