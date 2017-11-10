using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sulmar.WPFMVVM.ShopPracz.Models;

namespace Sulmar.WPFMVVM.ShopPracz.DbServices
{
    public class DbProductsService : IProductsService
    {
        private readonly ShopPraczContext context;

        public DbProductsService()
        {
            context = new ShopPraczContext();

            // umozliwa sledzenie zapytań SQL
            context.Database.Log = Console.WriteLine;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);

            context.SaveChanges();

        }

        public ICollection<Product> Get()
        {
            return context.Products.ToList();
        }

        public Product Get(int id)
        {
            var product = context.Products.Single(p=>p.Id == id);

            // context.Entry(product).State 

           // product.Color = "Blue";

            return product;
        }

        public Product Get(string name)
        {
            return context.Products.Single(p => p.Name == name);
        }

        public void Remove(int id)
        {
            var product = Get(id);

            context.Products.Remove(product);

            context.SaveChanges();
        }

        public void Update(Product product)
        {
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;

            var entities = context.ChangeTracker.Entries().ToList();

            context.SaveChanges();
        }
    }
}
