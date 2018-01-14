using System;
using businesstools.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace businesstools.Data.Repositories
{
    public interface IBusinessModelCanvasRepository
    {
        Task<List<CanvasData>> GetAll();
        Task<CanvasData> GetById(string id);
        Task<bool> Update(CanvasData canvas);
        Task<bool> Delete(string id);
    }
}
