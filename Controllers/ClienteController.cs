using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaAPI.connection;
    using OficinaAPI.Models;
using OficinaAPI.Repository;
using OficinaAPI.View;

namespace OficinaAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        //private readonly OficinaContext _context;
        private readonly iClienteRepository _iClienteRepository;

        public ClienteController(iClienteRepository iClienteRepository)
        {
            iClienteRepository = iClienteRepository ?? throw new ArgumentNullException(nameof(iClienteRepository));
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var clientes = _iClienteRepository.getAll();
            return Ok(clientes);

        }

        // GET: api/Cliente{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClientes(int id)
        {

            var cliente =  _iClienteRepository.getById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return  cliente;
        }

        // Post: api/Cliente
        [HttpPost]
        public IActionResult PostCliente(ClienteViewModel clienteView)
        {


            var cliente = new Cliente(clienteView.Nome, clienteView.Telefone, clienteView.Email, clienteView.Endereco);
            _iClienteRepository.add(cliente);

            return Ok();
        }



        // PUT: api/Cliente
        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest("[ERRO] => Cliente não Encontrado!!!");
            }
            _iClienteRepository.update(cliente);      
            return NoContent();
        }

        // DELETE: api/Cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Método auxiliar para o método DeleteCliente em caso de erro
        //private bool ClienteExists(int id)
        //{
        //    return _context.Clientes.Any(e => e.ClienteId == id);
        //}

    }
}
