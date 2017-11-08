using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class Order : Base
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public Customer Customer { get; set; }

        private ICollection<OrderDetail> details;
        public ICollection<OrderDetail> Details
        {
            get { return details; }
            set
            {
                details = value;

                foreach (var detail in Details)
                {
                    detail.PropertyChanged += Detail_PropertyChanged;
                }

                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private void Detail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Amount")
            {
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        public Order()
        {
            Details = new List<OrderDetail>();

            
        }

        public decimal TotalAmount
        {
            get
            {
                return Details.Sum(detail => detail.Amount);
            }
        }

        //public override string ToString()
        //{
        //    return $"{Number} {OrderDate}";
        //}

    }

    public enum OrderStatus
    {
        Created,

        Processing,

        Delivered,
    }
}
