global using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Assortiment.ViewModel
{
    internal class BrandVM:BindableBase
    {
        public BrandVM()
        {
            Items = new ListCollectionView(_brands);
        }
        #region Fields
        private ObservableCollection<Brand> _brands =
            Session.Context.Brands.Local.ToObservableCollection();
        #endregion
        #region Properties
        public ListCollectionView Items { get; set; }
        #endregion
    }
}
