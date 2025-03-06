using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{


    [Table("orcamentos")]
    public class Orcamento
    {

        [Column("orcamentoid")]
        public int OrcamentoId { get; set; }

        [Required]
        [Column("veiculoId")]
        public int VeiculoId { get; set; }

        [Required]
        [Column("clienteid")] // Add this line
        public int ClienteId { get; set; } // Add this property

        [Required]
        [Column("data")]
        public DateTime Data { get; set; }


        [Column("valor")]
        public decimal ValorTotal { get; set; }

        public List<ItemOrcamento> Itens { get; set; } = new List<ItemOrcamento>();

        [NotMapped] // Ignora a propriedade na criação do banco de dados
        public decimal Valor
        {
            get
            {
                return Itens?.Sum(i => i.Valor) ?? 0;
            }


        } // Propriedade somente leitura valor total do orçamento somado a partir dos itens

        //Entender como mapear no banco de dados a relação da coluna valor com a propriedade Valor ja que tem que ser somente leitura
        public Veiculo Veiculo { get; set; }
        public Cliente Cliente { get; set; }


    }
}
