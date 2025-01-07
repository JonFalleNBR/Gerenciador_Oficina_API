using Microsoft.AspNetCore.Mvc;
using OficinaAPI.DTO;
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

            var cliente = await iVeiculoRepository.GetClienteByIdAsync(veiculoView.ClienteId);
            if(cliente == null)
            {
                return NotFound("[ERRO: Cliente Não Encontrado na base de Dados! ]");
            }

            var veiculo = new Veiculo(veiculoView.Marca, veiculoView.Modelo, veiculoView.Ano, veiculoView.Placa, veiculoView.ClienteId);

            await iVeiculoRepository.AddAsync(veiculo);

            // logica para adicionar o veiculo ao cliente
            var veiculoCliente = new VeiculoDTO
            {
                VeiculoId = veiculo.VeiculoId,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
                ClienteId = veiculo.ClienteId,
                ClienteNome = cliente.Nome // Adicionando o nome do cliente ao veiculo para o usuario final
            };

            return Ok(veiculoCliente);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var veiculos = await iVeiculoRepository.GetAllAsync();


            var veiculoComCliente = veiculos.Select(veiculo => new VeiculoDTO
            {
                VeiculoId = veiculo.VeiculoId,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
                ClienteId = veiculo.ClienteId,
                ClienteNome = veiculo.Cliente.Nome
            }).ToList();


            return Ok(veiculoComCliente);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
            var veiculo = await iVeiculoRepository.GetByIdAsync(id);
            if (veiculo == null)
            {
                return NotFound("[ERRO: Veiculo Não Encontrado na base de Dados! ]");
            }

            var veiculoComCliente = new VeiculoDTO
            {
                VeiculoId = veiculo.VeiculoId,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
                ClienteId = veiculo.ClienteId,
                ClienteNome = veiculo.Cliente.Nome
            };
            return Ok(veiculoComCliente);
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
