using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{

    [Table("DescricaoServicos")]
    public class DescricaoServico
    {
        [Key]
        public int DescricaoServicoId { get; set; }
        public string Servico { get; set; }
        public decimal Preco { get; set; }
        public int ClienteId { get; set; }  // Chave estrangeira
        public Cliente Cliente { get; set; }  // Propriedade de navegaçã

    }
}
