using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using businesstools.Models;
using Microsoft.Extensions.Options;
using businesstools.Data.Repositories;
using businesstools.Models.MongoDb;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Diagnostics;

namespace businesstools.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BusinessModelCanvasController : Controller
    {
        protected IBusinessModelCanvasRepository _repository;

        public BusinessModelCanvasController(IBusinessModelCanvasRepository repository) {
            _repository = repository;
        }

        private string GetUserId() {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<CanvasDataRaw>> Get()
        {
            return await _repository.GetAll(GetUserId());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<CanvasDataRaw> Get(string id)
        {
            return await _repository.GetById(id, GetUserId());
        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody]CanvasDataRaw canvas)
        {
            canvas._id = ObjectId.GenerateNewId();
            canvas.BelongsTo = GetUserId();
            canvas.Channels = new CanvasCategoryRaw();
            canvas.CostStructure = new CanvasCategoryRaw();
            canvas.CustomerRelationships = new CanvasCategoryRaw();
            canvas.CustomerSegments = new CanvasCategoryRaw();
            canvas.KeyActivities = new CanvasCategoryRaw();
            canvas.KeyPartners = new CanvasCategoryRaw();
            canvas.KeyResources = new CanvasCategoryRaw();
            canvas.RevenueStreams = new CanvasCategoryRaw();
            canvas.ValuePropositions = new CanvasCategoryRaw();
            return await _repository.Add(canvas);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
        }

        [HttpPatch("{id}")]
        public async Task<bool> Patch(string id, [FromBody]CanvasDataRaw canvas) 
        {
            var canvasBefore = await _repository.GetById(id);
            if (canvasBefore.BelongsTo != GetUserId())
                throw new AccessViolationException("You are not allowed to change someone else's canvas.");

            canvas._id = new ObjectId(id);
            canvas.BelongsTo = GetUserId();
            return await _repository.Update(canvas);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            var canvasBefore = await _repository.GetById(id);
            if (canvasBefore.BelongsTo != GetUserId())
                throw new AccessViolationException("You are not allowed to delete someone else's canvas.");

            return await _repository.Delete(id);
        }
    }
}
