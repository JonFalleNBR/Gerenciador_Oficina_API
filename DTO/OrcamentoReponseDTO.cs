namespace OficinaAPI.DTO
{


    /*
     *  DTO para estruturar os dados especificamento na criação de um novo orçamento 
     *  Sim, dava pra usar o OrcamentoDTO, mas acho que é melhor separar as responsabilidades e deixar o OrcamentoDTO para a exibição de orçamentos
     *  No futuro para simplificação da estrutura, poderia ser feito um DTO genérico para orçamentos, mas por hora vou manter assim
     * 
     */
    public class OrcamentoReponseDTO
    {

        public int OrdemServico { get; set; }
        public  VeiculoResponseDTO Veiculo { get; set; }

        public string Cliente { get; set; }

        public string Descricao { get; set; }

            public decimal Valor { get; set; }

        public DateTime Data { get; set; }

       

    }
}
