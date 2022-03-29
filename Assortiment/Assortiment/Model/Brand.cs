using System;
using System.Collections.Generic;

namespace Assortiment.Model
{
    public partial class Brand
    {
        public Brand()
        {
            ProductBrands = new HashSet<ProductBrand>();
        }

        public int BrandId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductBrand> ProductBrands { get; set; }
    }
}
