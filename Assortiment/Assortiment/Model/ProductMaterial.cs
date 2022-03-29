using System;
using System.Collections.Generic;

namespace Assortiment.Model
{
    public partial class ProductMaterial
    {
        public int ProductMateriald { get; set; }
        public int ProductId { get; set; }
        public int Materiald { get; set; }
        public int Percents { get; set; }

        public virtual Material MaterialdNavigation { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
