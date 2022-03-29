using System;
using System.Collections.Generic;

namespace Assortiment.Model
{
    public partial class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public int ProviderId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
