using Sulmar.WPFMVVM.ShopPracz.Models;
using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.WPFMVVM.ShopPracz.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        public ICollection<Order> Orders { get; set; }

        private IOrdersService ordersService;



        public OrdersViewModel() 
            : this(new MockOrdersService())
        {
        }

        public OrdersViewModel(IOrdersService ordersService)
        {
            this.ordersService = ordersService;

            Load();
        }

        private void Load()
        {
            Orders = ordersService.Get();
        }
    }
}
