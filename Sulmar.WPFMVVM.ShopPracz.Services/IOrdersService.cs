using Sulmar.WPFMVVM.ShopPracz.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sulmar.WPFMVVM.ShopPracz.Services
{
    public interface IOrdersService
    {
        ICollection<Order> Get();
    }
}
