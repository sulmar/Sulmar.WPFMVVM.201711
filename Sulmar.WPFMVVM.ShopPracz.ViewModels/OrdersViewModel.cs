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

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get
            {
                return selectedOrder;
            }

            set
            {
                selectedOrder = value;
                GetOrderDetailsOfSelectedOrder();
            }
        }

        private IOrdersService ordersService;
        private IOrderDetailsService orderDetailsService;



        public OrdersViewModel() 
            : this(new MockOrdersService(), new MockOrderDetailsService())
        {
        }

        public OrdersViewModel(IOrdersService ordersService, IOrderDetailsService orderDetailsService)
        {
            this.ordersService = ordersService;
            this.orderDetailsService = orderDetailsService;

            Load();
        }

        private void Load()
        {
            Orders = ordersService.Get();
        }

        private void GetOrderDetailsOfSelectedOrder()
        {
            SelectedOrder.Details = orderDetailsService.Get(SelectedOrder.Id);
        }
    }
}
