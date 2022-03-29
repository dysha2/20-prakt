using System;
using System.Collections.Generic;

namespace Assortiment.Model
{
    public partial class KindOfProduct
    {
        public KindOfProduct()
        {
            Products = new HashSet<Product>();
        }

        public int KindOfProductId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
