using OficinaAPI.DTO;

namespace OficinaAPI.NewFolder
{
    public class ClientesDTO
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        
      
        public List<VeiculoDTO> Veiculos { get; set; }


    }
}
