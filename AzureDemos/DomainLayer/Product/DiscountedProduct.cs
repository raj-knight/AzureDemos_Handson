using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Prdct
{

    // POCO Class
    // It typically makes little sense to hide POCOs, DTOs, and view models behind an interface, 
    // because they contain no behavior that
    // requires  mocking,  InteRCeptION,  or  replacement

    public class DiscountedProduct
    {
        public DiscountedProduct(string name, decimal unitPrice)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
            UnitPrice = unitPrice;
        }

        public string Name { get; }
        public decimal UnitPrice { get; }
    }

}
