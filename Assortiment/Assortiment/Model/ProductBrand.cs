using System;
using System.Collections.Generic;

namespace Assortiment.Model
{
    public partial class ProductBrand
    {
        public int ProductBrandId { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
