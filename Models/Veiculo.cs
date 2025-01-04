using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{

    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int ClienteId { get; set; }  // Chave estrangeira
        public Cliente Cliente { get; set; }  // Propriedade de navegação


    }
}
