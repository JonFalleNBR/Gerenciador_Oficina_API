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
        [Column("data")]
        public DateTime Data { get; set; }


        public List<ItemOrcamento> Itens { get; set; }

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


    }
}
