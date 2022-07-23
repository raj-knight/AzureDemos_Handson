namespace DomainLayer.Prdct
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetFeaturedProducts();
    }
}