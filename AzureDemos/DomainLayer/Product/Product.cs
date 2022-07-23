using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Prdct
{
    //The Product class only contains the Name, UnitPrice, and IsFeatured properties, because those are the only properties needed to implement the desired application feature.
    //This method requires IUserContext as an argument. IUserContext is part of the domain layer, and we’ll define it shortly.

    public class Product
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsFeatured { get; set; }

        public DiscountedProduct ApplyDiscountFor(IUserContext user)
        {
            bool preferred = user.IsInRole(Role.PreferredCustomer);

            decimal discount = preferred ? .95m : 1.00m;

            return new DiscountedProduct(name: Name, unitPrice: UnitPrice * discount);
        }
    }

}
