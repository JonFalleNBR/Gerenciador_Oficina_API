using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{

    [Table("clientes")]
    public class Cliente
    {

        [Key]
        [Column("clienteid")]
        public int ClienteId { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }


        public Cliente(string nome, string telefone, string email, string endereco)
        {
            this.Nome = nome ?? throw new ArgumentException(nameof(nome));
            this.Telefone = telefone;
            this.Email = email;
            this.Endereco = endereco;
        }



        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();

        public ICollection<Orcamento> Orcamentos { get; set; }

    }
}
