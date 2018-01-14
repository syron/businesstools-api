using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using businesstools.Models;
using Microsoft.Extensions.Options;

namespace businesstools.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public string collectionId = "businessmodelcanvas";
        public IMongoClient _client;
        public IMongoDatabase _db;

        public ValuesController(IOptions<businesstools.Models.Settings> settings) {
            _client = new MongoClient(settings.Value.ConnectionString);
            _db = _client.GetDatabase(settings.Value.Database);
        }

        // GET api/values
        [HttpGet]
        public object Get()
        {
            var collection = _db.GetCollection<CanvasData>(collectionId);
            return collection.Find(new BsonDocument()).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
