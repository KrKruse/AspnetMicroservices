using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalzorUiMicroservice.Models;

namespace BalzorUiMicroservice.Services
{
    public interface IOrderingService
    {
        Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName);
    }
}
