using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Data;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Assortiment.ViewModel
{
    internal class MainVM : BindableBase
    {
        public static MainVM root;
        public ProviderVM ProviderVM { get; set; }
        public BrandVM BrandVM { get; set; }
        public MainVM()
        {
            ProviderVM = new ProviderVM();
            BrandVM = new BrandVM();
            CurrentContentVM=BrandVM;
            root = this;
        }
        #region Fields
        private BindableBase currentContentVM;

        #endregion
        #region Properties
        public BindableBase CurrentContentVM
        {
            get
            {
                return currentContentVM;
            }
            set
            {
                currentContentVM = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands

        public DelegateCommand<BindableBase> ChangeConrtol
        {
            get
            {
                return new DelegateCommand<BindableBase>(obj =>
                {
                    currentContentVM = obj;
                });
            }
        }
        #endregion
    }
}
