using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class Product : Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        #region Color

        private string color;

        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Price
     
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        #endregion


       // public string Size { get; set; }


        public float Weight { get; set; }

    }
}
