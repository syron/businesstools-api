﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using businesstools.Models;
using Microsoft.Extensions.Options;
using businesstools.Data.Repositories;

namespace businesstools.Controllers
{
    [Route("api/[controller]")]
    public class BusinessModelCanvasController : Controller
    {
        protected IBusinessModelCanvasRepository _repository;

        public BusinessModelCanvasController(IBusinessModelCanvasRepository repository) {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<CanvasData>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<CanvasData> Get(string id)
        {
            return await _repository.GetById(id);
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

        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody]string value) 
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}