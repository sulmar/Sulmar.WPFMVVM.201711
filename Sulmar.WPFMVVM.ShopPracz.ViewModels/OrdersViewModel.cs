using Sulmar.WPFMVVM.Common;
using Sulmar.WPFMVVM.ShopPracz.Models;
using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private readonly IOrdersService ordersService;
        private readonly IOrderDetailsService orderDetailsService;



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


        #region CalculateCommand

        public ICommand CalculateCommand
        {
            get
            {
                return new RelayCommand(p => Calculate(p), p => CanCalculate(p));
            }
        }

        public void Calculate(object p)
        {
            Console.WriteLine($"Calculate {this.SelectedOrder.Number}");
        }

        public bool CanCalculate(object p)
        {
            return this.SelectedOrder!=null;
        }

        #endregion
    }
}
