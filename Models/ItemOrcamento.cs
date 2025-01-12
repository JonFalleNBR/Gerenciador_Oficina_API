using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{


    [Table("itensorcamento")]
    public class ItemOrcamento
    {
        [Column("itemorcamentoid")]
        public int ItemOrcamentoId { get; set; }

        [Required]
        [Column("orcamentoId")]
        [ForeignKey("OrcamentoId")]
        public int OrcamentoId { get; set; } // Chave estrangeira não é ? 

        [Required]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Required]
        [Column("valor")]
        public decimal Valor { get; set; }

        public Orcamento Orcamento { get; set; } // Propriedade de navegação


    }
}
