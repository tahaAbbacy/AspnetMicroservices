using Catalog.API.Entitites;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DataBaseSettings:connectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DataBaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DataBaseSettings:CollectionName"));
            CatalogContextSeed.seedData(Products);
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
