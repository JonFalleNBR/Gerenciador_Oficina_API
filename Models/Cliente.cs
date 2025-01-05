using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaAPI.Models
{

    [Table("Clientes")]
    public class Cliente
    {

        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public string Endereco { get; set; }


        public Cliente(string nome, string telefone, string email, string endereco)
        {
            this.Nome = nome ?? throw new ArgumentException(nameof(nome));
            this.Telefone = telefone;
            this.Email = email;
            this.Endereco = endereco;
        }



        public ICollection<Veiculo> Veiculos { get; set; }
        public ICollection<DescricaoServico> DescricaoServicos { get; set; }

    }
}
