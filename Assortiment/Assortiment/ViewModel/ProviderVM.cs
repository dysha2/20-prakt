using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Assortiment.ViewModel
{
    internal class ProviderVM:BindableBase
    {
        public ProviderVM()
        {
            Items = new ListCollectionView(_providers);
        }
        #region Fields
        private ObservableCollection<Provider> _providers = 
            Session.Context.Providers.Local.ToObservableCollection();
        #endregion
        #region Properties
        public ListCollectionView Items { get; set; }
        #endregion
    }
}
