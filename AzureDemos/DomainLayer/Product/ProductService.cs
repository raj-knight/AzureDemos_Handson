using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Prdct
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IUserContext userContext;

        //CONSTRUCTOR INJECTION
        public ProductService(IProductRepository repository, IUserContext userContext)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            if (userContext == null) throw new ArgumentNullException("userContext");

            this.repository = repository;
            this.userContext = userContext;
        }

        //The repository and userContext DEPENDENCIES pull a list of products and apply a discount for each featured product, respectively.
        public IEnumerable<DiscountedProduct> GetFeaturedProducts()
        {
            return
                from product in repository.GetFeaturedProducts()
                select product.ApplyDiscountFor(userContext);
        }
    }
}
