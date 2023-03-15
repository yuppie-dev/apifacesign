using Facesign.Services.Entities.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facesign.Services.Infra.Data.Data.Context
{
    public class MongoDBContext : IDbContext
    {
        private IMongoDatabase? _database;

        public MongoDBContext(IOptions<DbConfiguration> settings)
        {
            var client = new MongoClient(BuildConfigurationModel.MongoConnectionString);
            if (client != null)
                _database = client.GetDatabase("facetec-sdk-data");

        }

        public void Dispose()
        {
            
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public class DbConfiguration
        {
            public string? ConnectionString { get; set; }
            public string? Database { get; set; }
        }
    }
}
