﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class Order : Base
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> Details { get; set; }

    }

    public enum OrderStatus
    {
        Created,

        Processing,

        Delivered,
    }
}