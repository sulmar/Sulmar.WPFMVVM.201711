using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class OrderDetail : Base
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Amount));
            }
        }

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set
            {
                unitPrice = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Amount));
            }
        }

        public decimal TaxRate { get; set; }

        public decimal Amount
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

        public int OrderId { get; set; }
    }
}
