namespace OficinaAPI.DTO
{
    public class OrcamentoDTO
    {

        public int OS { get; set; }

        public string VeiculoNome { get; set; }

        public string ClienteNome { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorTotal { get; set; }

        public List<ItemOrcamentoDTO> Itens { get; set; }


    }
}
