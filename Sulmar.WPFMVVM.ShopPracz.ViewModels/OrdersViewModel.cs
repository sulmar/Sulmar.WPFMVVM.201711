using Sulmar.WPFMVVM.Common4;
using Sulmar.WPFMVVM.ShopPracz.DbServices;
using Sulmar.WPFMVVM.ShopPracz.MockServices;
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
        private ICollection<Order> orders;
        public ICollection<Order> Orders
        {
            get
            {
                return orders;
            }

            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

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
                
                // wyzwalamy sprawdzenie CanExecute
               // CalculateCommand.OnCanExecuteChanged();

                GetOrderDetailsOfSelectedOrder();
                OnPropertyChanged();
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
        }

        public RelayCommand LoadCommand
        {
            get
            {
                return new RelayCommand(p => Load());
            }
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

        public RelayCommand CalculateCommand
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
            return this.SelectedOrder!=null 
                && SelectedOrder.Status == OrderStatus.Created;
        }

        #endregion
    }
}
