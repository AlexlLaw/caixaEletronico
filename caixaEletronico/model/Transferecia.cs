namespace caixaEletronico.model
{
    public class Transferecia
    {
        public int TransfereciaId { get; set; }
        public int ContaId { get; set; }
        public string DataDeTransferencia { get; set; }
        public string descricao { get; set; }
        public decimal Valor { get; set; }
        public int ContaCreditadoId { get; set; }
    }
}