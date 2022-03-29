using System;
using System.Collections.Generic;

namespace Assortiment.Model
{
    public partial class Product
    {
        public Product()
        {
            ProductBrands = new HashSet<ProductBrand>();
            ProductMaterials = new HashSet<ProductMaterial>();
        }

        public int ProductId { get; set; }
        public int KindOfProductId { get; set; }
        public string Size { get; set; } = null!;
        public decimal Price1 { get; set; }
        public decimal? Price2 { get; set; }
        public decimal? Price3 { get; set; }
        public decimal? PackagePrice { get; set; }
        public int ProviderId { get; set; }
        public string? Comment { get; set; }

        public virtual KindOfProduct KindOfProduct { get; set; } = null!;
        public virtual Provider Provider { get; set; } = null!;
        public virtual ICollection<ProductBrand> ProductBrands { get; set; }
        public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }
    }
}
