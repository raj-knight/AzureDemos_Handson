using DomainLayer;
using DomainLayer.Prdct;

namespace DataAccessLayer.Prdct
{

    public class SqlProductRepository : IProductRepository
    {
        private readonly CommerceContext context;

        public SqlProductRepository(CommerceContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            return
            from product in context.Products
            where product.IsFeatured
            select product;
        }
    }

}