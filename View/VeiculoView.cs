using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OficinaAPI.View
{
    public class VeiculoView
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }
    
        public string Placa { get; set; }
   
        public int Ano { get; set; }

        public int ClienteId { get; set; }

    }
}
