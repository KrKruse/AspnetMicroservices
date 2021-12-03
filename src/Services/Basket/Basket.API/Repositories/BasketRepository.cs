using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        // inject cache.distrubeted - en cache er en hurtig løsning til at gemme data - bruger IDistributedCache som en redis cache 
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            // basket object vil blive hele json filen
            var basket = await _redisCache.GetStringAsync(userName);

            // tjekke om der er noget i basket 
            if (String.IsNullOrEmpty(basket))
                return null;

            // convert json til shoppingcart - bruger jsonconvert til at gemme og hente fra redisdb 
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        // update vil blive create og update 
        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            // convert til json 
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }

        // slet
        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
