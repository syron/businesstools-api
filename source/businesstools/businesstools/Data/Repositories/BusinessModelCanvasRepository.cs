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

        public async Task<List<CanvasDataRaw>> GetAll()
        {
            return await _bmcCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<CanvasDataRaw>> GetAll(string userId)
        {
            var builder = Builders<CanvasDataRaw>.Filter;
            var filter = builder.Eq("BelongsTo", userId);
            return await _bmcCollection.Find(filter).ToListAsync();
        }

        public async Task<CanvasDataRaw> GetById(string id)
        {
            var builder = Builders<CanvasDataRaw>.Filter;
            var filter = builder.Eq("_id", new ObjectId(id));

            return await _bmcCollection.Find(filter).FirstAsync();
        }

        public async Task<CanvasDataRaw> GetById(string id, string userId)
        {
            var builder = Builders<CanvasDataRaw>.Filter;
            var filter = builder.Eq("_id", new ObjectId(id)) & builder.Eq("BelongsTo", userId);

            return await _bmcCollection.Find(filter).FirstAsync();
        }

        public async Task<bool> Update(CanvasDataRaw canvas)
        {
            var builder = Builders<CanvasDataRaw>.Filter;
            var filter = builder.Eq(s => s._id, canvas._id);
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
