namespace OficinaAPI.DTO
{
    public class CreateOrcamentoDTO
    {
        public int VeiculoId { get; set; }
        public int ClienteId { get; set; } // Add this property

        public List<CreateItemOrcamentoDTO> Itens { get; set; }


    }
}
