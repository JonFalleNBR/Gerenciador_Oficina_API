using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{

    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]

        [Column("veiculoid")]
        public int VeiculoId { get; set; }

        [Required]
        [Column("marca")]
        public string Marca { get; set; }


        [Required]
        [Column("modelo")]
        public string Modelo { get; set; }

        [Required]
        [StringLength(50)]
        [Column("placa")]
        public string Placa { get; set; }


        [Required]
        [StringLength(8)]
        [Range(1970, int.MaxValue, ErrorMessage = "[O Ano deve ser igual ou superior a 1970!]")]
        [Column("ano")]
        public int Ano { get; set; }


        [Column("clienteid")]
        public int ClienteId { get; set; }  // Chave estrangeira

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }  // Propriedade de navegação




         public Veiculo (string marca, string modelo, int ano, string placa, int clienteId)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Placa = placa;
            this.Ano = ano;
            

        }
    }
}
