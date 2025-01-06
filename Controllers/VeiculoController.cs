using Microsoft.AspNetCore.Mvc;
using OficinaAPI.Models;
using OficinaAPI.Repository;
using OficinaAPI.View;

namespace OficinaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly iVeiculoRepository iVeiculoRepository;


        public VeiculoController(iVeiculoRepository veiculoRepository)
        {
            iVeiculoRepository = veiculoRepository ?? throw new ArgumentNullException(nameof(veiculoRepository));
        }


        [HttpPost]
        public async Task<IActionResult> PostVeiculo(VeiculoView veiculoView)
        {
            var veiculo = new Veiculo(veiculoView.Marca, veiculoView.Modelo, veiculoView.Ano, veiculoView.Placa, veiculoView.ClienteId);

            await iVeiculoRepository.AddAsync(veiculo);
            return Ok(veiculo);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var veiculos = await iVeiculoRepository.GetAllAsync();
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await iVeiculoRepository.GetByIdAsync(id);
            if (veiculo == null)
            {
                return NotFound("[ERRO: Veiculo Não Encontrado na base de Dados! ]");
            }
            return veiculo;
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> PutVeiculo(int id, VeiculoView veiculoView)
        {
            var veiculo = new Veiculo(veiculoView.Marca, veiculoView.Modelo, veiculoView.Ano, veiculoView.Placa, veiculoView.ClienteId);
            veiculo.VeiculoId = id;
            await iVeiculoRepository.UpdateAsync(veiculo);
            return Ok(veiculo);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await iVeiculoRepository.GetByIdAsync(id);
            if (veiculo == null)
            {
                return NotFound("[ERRO: Veiculo Não Encontrado na base de Dados! ]");
            }
            await iVeiculoRepository.DeleteAsync(veiculo);
            return Ok(veiculo);
        }

    }
}
