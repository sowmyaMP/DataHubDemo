namespace Domain.Datahub
{
    public interface IProductCreate
    {
        string CreateProduct();

        string CreateProductInUse(string productIndustry, string packagingLevel);

        string CreateProductInDraft(string productIndustry, string packagingLevel);
    }
}
