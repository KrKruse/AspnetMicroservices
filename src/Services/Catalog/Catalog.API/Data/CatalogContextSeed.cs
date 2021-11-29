using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        // hvis der ikke er nogen produkter, seeder den produkter ind 
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        // seed af produkterne
        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Playstation 5",
                    Summary = "Spilkonsolen Playsation 5",
                    Description = "Spilkonsol",
                    ImageFile = "product-1.png",
                    Price = 3000,
                    Category = "Console"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Playstation 4",
                    Summary = "Spilkonsolen Playsation 5",
                    Description = "Spilkonsol",
                    ImageFile = "product-2.png",
                    Price = 2000,
                    Category = "Console"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Xbox One",
                    Summary = "Spilkonsolen Xbox One",
                    Description = "Spilkonsol",
                    ImageFile = "product-3.png",
                    Price = 2500,
                    Category = "Console"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Wii",
                    Summary = "Spilkonsolen Wii",
                    Description = "Spilkonsol",
                    ImageFile = "product-4.png",
                    Price = 750,
                    Category = "Console"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Nintendo",
                    Summary = "Spilkonsolen Nintendo",
                    Description = "Spilkonsol",
                    ImageFile = "product-5.png",
                    Price = 1200,
                    Category = "Retro Console"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Sega",
                    Summary = "Spilkonsolen Sega",
                    Description = "Spilkonsol",
                    ImageFile = "product-6.png",
                    Price = 1500,
                    Category = "Retro Console"
                }
            };
        }
}
