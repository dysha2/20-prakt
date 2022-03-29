using System;
using System.Collections.Generic;

namespace Assortiment.Model
{
    public partial class Material
    {
        public Material()
        {
            ProductMaterials = new HashSet<ProductMaterial>();
        }

        public int MateriaId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }
    }
}
