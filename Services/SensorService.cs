using ApiSensoresIOT.Model;
using ApiSensoresIOT.Repositories.Interfaces;

namespace ApiSensoresIOT.Services
{
    public class SensorService
    {
        private readonly ISensorRepository _repo;

        public SensorService(ISensorRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Sensor>> Listar()
            => await _repo.GetAll();

        public async Task<Sensor> ObterPorId(int id)
            => await _repo.GetById(id);

        public async Task Criar(Sensor sensor)
        {
            if (sensor.Valor < -100 || sensor.Valor > 200)
                throw new Exception("Valor do sensor fora do intervalo permitido.");

            sensor.DataCriacao = DateTime.Now;
            sensor.DataAtualizacao = DateTime.Now;

            await _repo.Add(sensor);
        }

        public async Task Atualizar(int id, Sensor sensor)
        {
            var existente = await _repo.GetById(id);

            if (existente == null)
                throw new Exception("Sensor não encontrado.");

            existente.Nome = sensor.Nome;
            existente.Tipo = sensor.Tipo;
            existente.Valor = sensor.Valor;
            existente.Unidade = sensor.Unidade;
            existente.DataLeitura = sensor.DataLeitura;
            existente.Localizacao = sensor.Localizacao;
            existente.Ativo = sensor.Ativo;
            existente.DataAtualizacao = DateTime.Now;

            await _repo.Update(existente);
        }

        public async Task Deletar(int id)
        {
            var existente = await _repo.GetById(id);

            if (existente == null)
                throw new Exception("Sensor não encontrado.");

            await _repo.Delete(id);
        }
    }
}