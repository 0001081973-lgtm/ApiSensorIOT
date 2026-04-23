using ApiSensoresIOT.Model;
using ApiSensoresIOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSensoresIOT.Controllers
{
    /// <summary>
    /// Controller responsável pelo monitoramento de sensores IoT
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly SensorService _service;

        /// <summary>
        /// Construtor da controller
        /// </summary>
        public SensorController(SensorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os sensores cadastrados
        /// </summary>
        /// <remarks>
        /// Este endpoint consulta o banco de dados e retorna a lista completa de sensores IoT cadastrados no sistema.
        /// É utilizado para monitoramento geral dos dispositivos ativos e inativos.
        /// </remarks>
        /// <returns>Lista de sensores</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var dados = await _service.Listar();
            return Ok(dados);
        }

        /// <summary>
        /// Retorna um sensor pelo ID
        /// </summary>
        /// <remarks>
        /// Este endpoint busca um sensor específico utilizando seu identificador único (ID).
        /// Caso o sensor não exista, será retornado erro 404.
        /// </remarks>
        /// <param name="id">ID do sensor</param>
        /// <returns>Sensor encontrado ou erro 404</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var dado = await _service.ObterPorId(id);

            if (dado == null)
                return NotFound($"Sensor com ID {id} não foi encontrado.");

            return Ok(dado);
        }

        /// <summary>
        /// Cria um novo sensor
        /// </summary>
        /// <remarks>
        /// Este endpoint permite o cadastro de um novo sensor IoT no sistema.
        /// Os dados enviados serão validados e persistidos no banco de dados SQLite.
        /// </remarks>
        /// <param name="sensor">Dados do sensor</param>
        /// <returns>Sensor criado ou erro interno</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] Sensor sensor)
        {
            try
            {
                await _service.Criar(sensor);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = sensor.Id },
                    sensor
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um sensor existente
        /// </summary>
        /// <remarks>
        /// Este endpoint atualiza as informações de um sensor já cadastrado.
        /// É necessário informar o ID na URL e os novos dados no corpo da requisição.
        /// Caso o ID da URL seja diferente do corpo, a requisição será rejeitada.
        /// </remarks>
        /// <param name="id">ID do sensor</param>
        /// <param name="sensor">Dados atualizados</param>
        /// <returns>Sem conteúdo ou erro</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Sensor sensor)
        {
            if (id != sensor.Id)
                return BadRequest("O ID da URL é diferente do ID do corpo.");

            try
            {
                await _service.Atualizar(id, sensor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Remove um sensor pelo ID
        /// </summary>
        /// <remarks>
        /// Este endpoint remove permanentemente um sensor do banco de dados.
        /// Após a exclusão, o sensor não poderá ser recuperado.
        /// </remarks>
        /// <param name="id">ID do sensor</param>
        /// <returns>Mensagem de sucesso ou erro</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Deletar(id);

                return Ok($"Sensor com ID {id} foi removido com sucesso.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}