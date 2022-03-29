global using Assortiment.Model;
global using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assortiment
{
    public class Session
    {
        private static AssortimentContext _context;
        private Session() { }
        public static AssortimentContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new AssortimentContext();
                    _context.Materials.Load();
                    _context.KindOfProducts.Load();
                    _context.Brands.Load();
                    _context.Products.Load();
                    _context.ProductBrands.Load();
                    _context.ProductMaterials.Load();
                    _context.Providers.Load();
                }
                return _context;
            }
        }
    }
}
