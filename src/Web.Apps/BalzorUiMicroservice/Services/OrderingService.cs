using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BalzorUiMicroservice.Extensions;
using BalzorUiMicroservice.Models;

namespace BalzorUiMicroservice.Services
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _client;

        public OrderingService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _client.GetAsync($"/Order/{userName}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
