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
        public async Task<IActionResult> Create([FromBody] Orcamento orcamentoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           if(orcamentoDTO.VeiculoId <= 0) // modificar para o isValid
            {
                return BadRequest("[ERRO: Veiculo invalido!]");

            }

           
            if(orcamentoDTO.Itens == null || orcamentoDTO.Itens.Count == 0)
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

            //salvando o orçamento no banco de Dados
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


    }
}
