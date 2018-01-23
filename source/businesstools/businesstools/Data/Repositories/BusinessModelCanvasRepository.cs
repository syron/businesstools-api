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

        public async Task<bool> Delete(string id)
        {
            try {
                var _id = new ObjectId(id);
                var filter = Builders<CanvasDataRaw>.Filter.Eq(s => s._id, _id);
                var result = await _bmcCollection.DeleteOneAsync(filter);

                if (result.DeletedCount >= 1)
                    return true;

                return false;
            }
            catch {
                return false;
            }
        }

        public Task<List<CanvasDataRaw>> GetAll()
        {
            return _bmcCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<CanvasDataRaw> GetById(string id)
        {
            return await _bmcCollection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync();
        }

        public async Task<bool> Update(CanvasDataRaw canvas)
        {
            var filter = Builders<CanvasDataRaw>.Filter.Eq(s => s._id, canvas._id);
            var result = await this._bmcCollection.ReplaceOneAsync(filter, canvas);
            return result.IsAcknowledged;
        }

        public async Task<bool> Add(CanvasDataRaw canvas) {
            try
            {
                await this._bmcCollection.InsertOneAsync(canvas);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
