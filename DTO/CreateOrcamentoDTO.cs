namespace OficinaAPI.DTO
{
    public class CreateOrcamentoDTO
    {
        public int VeiculoId { get; set; }
        public List<CreateItemOrcamentoDTO> Itens { get; set; }


    }
}
