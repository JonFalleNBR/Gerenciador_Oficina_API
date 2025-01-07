using OficinaAPI.Models;
using OficinaAPI.NewFolder;

namespace OficinaAPI.DTO
{
    public class VeiculoDTO
    {

        public int VeiculoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }


        public int ClienteId { get; set; }  // Chave estrangeira
        public string ClienteNome { get; set; }  // Propriedade de navegação

    }

}
