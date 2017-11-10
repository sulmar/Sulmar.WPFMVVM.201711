﻿using Sulmar.WPFMVVM.Common4;
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
            : this(new MockProductsService())
        {
            
        }

        private void Load()
        {
            Products = new ObservableCollection<Product>(productsService.Get());
        }

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

        private bool IsSelectedProduct => SelectedProduct != null;
      
    }
}
