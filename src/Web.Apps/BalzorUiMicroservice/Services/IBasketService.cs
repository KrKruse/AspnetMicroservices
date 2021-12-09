﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalzorUiMicroservice.Models;

namespace BalzorUiMicroservice.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel model);
        Task CheckoutBasket(BasketCheckoutModel model);
    }
}
