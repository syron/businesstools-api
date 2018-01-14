using System;
using businesstools.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using businesstools.Models.MongoDb;

namespace businesstools.Data.Repositories
{
    public interface IBusinessModelCanvasRepository
    {
        Task<List<CanvasDataRaw>> GetAll();
        Task<CanvasDataRaw> GetById(string id);
        Task<bool> Update(CanvasDataRaw canvas);
        Task<bool> Delete(string id);
    }
}
