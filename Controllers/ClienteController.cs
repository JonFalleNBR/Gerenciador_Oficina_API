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

        public ClienteController(iClienteRepository clienteRepository)
        {
            _iClienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }


        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var clientes = await _iClienteRepository.GetAllAsync();
            return Ok(clientes);

        }

        // GET: api/Cliente{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClientes(int id)
        {

            var cliente = await _iClienteRepository.GetByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return  cliente;
        }

        // Post: api/Cliente
        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteViewModel clienteView)
        {


            var cliente = new Cliente(clienteView.Nome, clienteView.Telefone, clienteView.Email, clienteView.Endereco);
      


            await _iClienteRepository.AddAsync(cliente);

            // var cliente = new Cliente(clienteView.Nome, clienteView.Telefone, clienteView.Email, clienteView.Endereco);
            //await  _iClienteRepository.add(cliente);

            return CreatedAtAction(nameof(GetClientes), new { id = cliente.ClienteId }, cliente);
        }



        // PUT: api/Cliente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteViewModel clienteView)
        {

            var cliente = await _iClienteRepository.GetByIdAsync(id);
            if (id != cliente.ClienteId)
            {
                return BadRequest("[ERRO] => Cliente não Encontrado!!!");
            }

            cliente.Nome = clienteView.Nome;
            cliente.Telefone = clienteView.Telefone;
            cliente.Email = clienteView.Email;
            cliente.Endereco = clienteView.Endereco;

            await _iClienteRepository.UpdateAsync(cliente);
            return NoContent();
        }

        // DELETE: api/Cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {


            var cliente = await _iClienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("[ERRO] => Cliente não Encontrado!!!");
            }
            await _iClienteRepository.DeleteAsync(cliente);
            return NoContent();



        }

    }
}
