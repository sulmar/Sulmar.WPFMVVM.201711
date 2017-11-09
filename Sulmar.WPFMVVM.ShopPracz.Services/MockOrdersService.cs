using System;
using System.Collections.Generic;
using System.Text;
using Sulmar.WPFMVVM.ShopPracz.Models;
using System.Linq;

namespace Sulmar.WPFMVVM.ShopPracz.Services
{
    public class MockOrdersService : IOrdersService
    {
        private ICollection<Order> orders;


        public MockOrdersService()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
            };

            orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Number = "ZAM 1",
                    OrderDate = DateTime.Now,
                    Customer = customer,
                },

                new Order
                {
                    Id = 2,
                    Number = "ZAM 2",
                    OrderDate = DateTime.Now,
                    Customer = customer,
                    Status = OrderStatus.Delivered
                },


                  new Order
                {
                    Id = 3,
                    Number = "ZAM 3",
                    OrderDate = DateTime.Now,
                    Customer = customer,
                    Status = OrderStatus.Processing
                },
            };
        }

        public ICollection<Order> Get()
        {
            return orders;
        }

        public Order Get(int id)
        {
            return orders.Single(o => o.Id == id);
        }
    }
}
