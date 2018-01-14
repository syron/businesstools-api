using System;
using businesstools.Models;
using System.Threading.Tasks;

namespace businesstools.Data.Repositories
{
    public interface IBusinessModelCanvasRepository
    {
        Task<CanvasData> GetAll();
        Task<CanvasData> GetById(int id);
        Task<bool> Update(CanvasData canvas);
        Task<bool> Delete(int id);
    }
}
