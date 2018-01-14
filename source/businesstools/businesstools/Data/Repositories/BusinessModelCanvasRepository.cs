using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using businesstools.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace businesstools.Data.Repositories
{
    public class BusinessModelCanvasRepository : IBusinessModelCanvasRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected IMongoCollection<CanvasData> _collection;

        public BusinessModelCanvasRepository(businesstools.Models.Settings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.Database);
            _collection = _database.GetCollection<CanvasData>("businessmodelcanvas");
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CanvasData>> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToListAsync();
        }

        public Task<CanvasData> GetById(string id)
        {
            return _collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync();
        }

        public async Task<bool> Update(CanvasData canvas)
        {
            var filter = Builders<CanvasData>.Filter.Eq(s => s._id, canvas._id);
            var result = await this._collection.ReplaceOneAsync(filter, canvas);
            return result.IsAcknowledged;
        }
    }
}
