using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        // get order fra username/bruger - Hele mappen Persistence er til at arbejde med database relaterede ting 
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
