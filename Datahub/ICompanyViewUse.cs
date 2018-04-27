namespace Domain.Datahub
{
    public interface ICompanyViewUse
    {
        bool SearchByCompanyName(string companyName, string streetAddress, string city, string zip);

        bool SearchByPrefix(string prefix);

        bool SearchByGTIN(string gTIN);

        bool SearchByGLN(string gLN);

        string ReturnSearchResultCompanyInDatatable();

        bool SearchInDatatableByFilter(string companyName, string status);

        bool CheckStatusOfSearchButton();

        bool OpenSearchByCompanyTab();

        bool OpenSearchByPrefixTab();

        bool OpenSearchByGLNTab();

        bool OpenSearchByGTINTab();

        bool ClickOnSearch();
    }
}
