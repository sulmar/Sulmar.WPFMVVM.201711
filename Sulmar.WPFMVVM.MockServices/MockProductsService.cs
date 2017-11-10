using System;
using System.Collections.Generic;
using System.Text;
using Sulmar.WPFMVVM.ShopPracz.Models;
using System.Linq;
using Sulmar.WPFMVVM.ShopPracz.Services;

namespace Sulmar.WPFMVVM.ShopPracz.MockServices
{
    public class MockProductsService : IProductsService
    {
        private ICollection<Product> products;

        public MockProductsService()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Color = "Red", Name = "Produkt 1", Price = 99.9m },
                new Product { Id = 2, Color = "Blue", Name = "Produkt 2", Price = 199.9m },
                new Product { Id = 3, Color = "Blue", Name = "Produkt 3", Price = 49.9m },
                new Product { Id = 4, Color = "Green", Name = "Produkt 4", Price = 89.2m },
                new Product { Id = 5, Color = "Red", Name = "Produkt 5", Price = 19.9m },
            };
        }

        public void Add(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;

            products.Add(product);
        }

        public ICollection<Product> Get()
        {
            return products;
        }


        public Product Get(int id) => products.Single(p => p.Id == id);

        public Product Get(string name)
        {
            // jeśli będzie więcej niż 1 to rzuci wyjątkiem
            return products.Single(p => p.Name == name);

            // jeśli będzie więcej niż 1 to zwraca pierwszy(!) element
            // return products.First(p => p.Name == name);

        }

        public void Remove(int id)
        {
            var product = Get(id);

            products.Remove(product);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
