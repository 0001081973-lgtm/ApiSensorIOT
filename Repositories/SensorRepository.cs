using ApiSensoresIOT.Data;
using ApiSensoresIOT.Repositories.Interfaces;
using ApiSensoresIOT.Data;
using ApiSensoresIOT.Model;
using Microsoft.EntityFrameworkCore;

namespace APIIoT.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly AppDbContext _context;

        public SensorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sensor>> GetAll()
            => await _context.Sensores.ToListAsync();

        public async Task<Sensor> GetById(int id)
            => await _context.Sensores.FindAsync(id);

        public async Task Add(Sensor sensor)
        {
            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Sensor sensor)
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor != null)
            {
                _context.Sensores.Remove(sensor);
                await _context.SaveChangesAsync();
            }
        }
    }
}