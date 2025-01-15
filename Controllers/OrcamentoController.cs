using Microsoft.AspNetCore.Mvc;
using OficinaAPI.DTO;
using OficinaAPI.Models;
using OficinaAPI.Repository;

namespace OficinaAPI.Controllers
{


    [Route("api/[controller]")]

    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly iOrcamentoRepository _orcamentoRepository;

        public OrcamentoController(iOrcamentoRepository orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var orcamentos = await _orcamentoRepository.GetAllOrcamentosWithDetailsAsync();

            var orcamentoDTO = orcamentos.Select(o => new OrcamentoDTO
            {
                OS = o.OrcamentoId,
                VeiculoNome = o.Veiculo.Modelo,
                ClienteNome = o.Veiculo.Cliente.Nome,
                Data = o.Data,
                ValorTotal = o.Itens.Sum(i => i.Valor),
                Itens = o.Itens.Select(i => new ItemOrcamentoDTO
                {
                    Descricao = i.Descricao,
                    Valor = i.Valor
                }).ToList()
            });
            return Ok(orcamentoDTO);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var orcamento = await _orcamentoRepository.GetOrcamentoByIdWithDetailsAsync(id);
            if (orcamento == null)
            {
                return NotFound("[ERRO: Orçamento não encontrado!]");
            }

            var orcamentoDTO = new OrcamentoDTO
            {
                OS = orcamento.OrcamentoId,
                VeiculoNome = orcamento.Veiculo.Marca + " " + orcamento.Veiculo.Modelo, // trazendo a marca e o modelo do veiculo 
                ClienteNome = orcamento.Veiculo.Cliente.Nome,
                Data = orcamento.Data,
                ValorTotal = orcamento.Valor,
                Itens = orcamento.Itens.Select(i => new ItemOrcamentoDTO
                {
                    Descricao = i.Descricao,
                    Valor = i.Valor
                }).ToList()
            };
            return Ok(orcamentoDTO);
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrcamentoDTO orcamentoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (orcamentoDTO.VeiculoId <= 0)
            {
                return BadRequest("[ERRO: Veículo inválido!]");
            }

            if (orcamentoDTO.Itens == null || orcamentoDTO.Itens.Count == 0)
            {
                return BadRequest("[ERRO: O Orçamento deve conter ao menos um item!]");
            }

            var orcamento = new Orcamento
            {
                VeiculoId = orcamentoDTO.VeiculoId,
                Data = DateTime.UtcNow,
                Itens = orcamentoDTO.Itens.Select(i => new ItemOrcamento
                {
                    Descricao = i.Descricao,
                    Valor = i.Valor
                }).ToList()
            };

            await _orcamentoRepository.AddAsync(orcamento);

            var response = new OrcamentoDTO
            {
                OS = orcamento.OrcamentoId,
                VeiculoNome = $"{orcamento.Veiculo.Marca} {orcamento.Veiculo.Modelo}",
                ClienteNome = orcamento.Veiculo.Cliente.Nome,
                Data = orcamento.Data,
                ValorTotal = orcamento.Itens.Sum(i => i.Valor),
                Itens = orcamento.Itens.Select(i => new ItemOrcamentoDTO
                {
                    Descricao = i.Descricao,
                    Valor = i.Valor
                }).ToList()
            };

            return CreatedAtAction(nameof(GetById), new { id = orcamento.OrcamentoId }, response);
        }

        /* TODO
         * Ajustar a configuração da Entidade 
         * 
         * Certifique-se de que as entidades estão corretamente mapeadas e 
         * que as propriedades de navegação estão configuradas corretamente.
         * 
         * Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while saving the entity changes. 
         * See the inner exception for details. --->
         * Npgsql.PostgresException (0x80004005): 
         * 42703: column "ClienteId" of relation "orcamentos" does not exist
         */        
        
    }
}
