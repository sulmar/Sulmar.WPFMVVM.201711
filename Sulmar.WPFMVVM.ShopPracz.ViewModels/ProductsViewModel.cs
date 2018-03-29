using Sulmar.WPFMVVM.Common4;
using Sulmar.WPFMVVM.ShopPracz.DbServices;
using Sulmar.WPFMVVM.ShopPracz.MockServices;
using Sulmar.WPFMVVM.ShopPracz.Models;
using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sulmar.WPFMVVM.ShopPracz.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {

        private ICollection<Product> products;
        public ICollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedProduct { get; set; }


        private readonly IProductsService productsService;

        public ProductsViewModel(IProductsService productsService)
        {
            this.productsService = productsService;

            Load();
        }

        public ProductsViewModel()
            : this(new DbProductsService())
        {

        }

        private void Load()
        {
            Products = new ObservableCollection<Product>(productsService.Get());
        }


        #region SelectCommand

        private ICommand _SelectCommand;
        public ICommand SelectCommand
        {
            get
            {
                if (_SelectCommand == null)
                {
                    _SelectCommand = new RelayCommand(p => Select());
                }

                return _SelectCommand;
            }
        }


        private void Select()
        {

        }

        #endregion  



        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(p => Add());
            }
        }

        private void Add()
        {
            // TODO: Show ProductView
            var product = new Product { Name = "Produkt 1", Color = "Red", Price = 99.9m };

            // navigationService.Navigate("ProductView");

            productsService.Add(product);
            this.Products.Add(product);
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new RelayCommand(p => Remove(), p => CanRemove());
            }
        }

        private void Remove()
        {
            productsService.Remove(SelectedProduct.Id);
            this.Products.Remove(SelectedProduct);
        }

        private bool CanRemove()
        {
            return IsSelectedProduct;
        }



        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(p => Update(), p => CanUpdate());
            }
        }

        private void Update()
        {
            productsService.Update(SelectedProduct);
        }

        private bool CanUpdate()
        {
            return IsSelectedProduct;
        }

        private bool IsSelectedProduct => SelectedProduct != null;
      
    }
}
