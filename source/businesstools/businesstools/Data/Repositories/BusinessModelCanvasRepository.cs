using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using businesstools.Models;
using businesstools.Models.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace businesstools.Data.Repositories
{
    public class BusinessModelCanvasRepository : IBusinessModelCanvasRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<CanvasDataRaw> _bmcCollection;

        public BusinessModelCanvasRepository(businesstools.Models.Settings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.Database);
            _bmcCollection = _database.GetCollection<CanvasDataRaw>("businessmodelcanvas");
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CanvasDataRaw>> GetAll()
        {
            return _bmcCollection.Find(new BsonDocument()).ToListAsync();
        }

        public Task<CanvasDataRaw> GetById(string id)
        {
            return _bmcCollection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync();
        }

        public async Task<bool> Update(CanvasDataRaw canvas)
        {
            var filter = Builders<CanvasDataRaw>.Filter.Eq(s => s._id, canvas._id);
            var result = await this._bmcCollection.ReplaceOneAsync(filter, canvas);
            return result.IsAcknowledged;
        }
    }
}
