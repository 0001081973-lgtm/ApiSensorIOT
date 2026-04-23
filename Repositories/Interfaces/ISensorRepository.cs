using ApiSensoresIOT.Model;

namespace ApiSensoresIOT.Repositories.Interfaces
{
    public interface ISensorRepository
    {
        Task<List<Sensor>> GetAll();
        Task<Sensor> GetById(int id);
        Task Add(Sensor sensor);
        Task Update(Sensor sensor);
        Task Delete(int id);
    }
}
