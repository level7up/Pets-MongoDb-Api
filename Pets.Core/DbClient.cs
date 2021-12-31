using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Pet> _pets;
        public DbClient(IOptions<PetsDBConfig> petDbConfig)
        {
            var client = new MongoClient(petDbConfig.Value.Connection_String);
            var database = client.GetDatabase(petDbConfig.Value.Database_Name);
            _pets = database.GetCollection<Pet>(petDbConfig.Value.Pets_Collection_Name);
        }
        public IMongoCollection<Pet> GetPetsCollection()
        {
            return _pets;
        }
    }
}
