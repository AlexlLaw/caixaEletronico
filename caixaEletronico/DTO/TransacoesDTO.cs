using System;

namespace caixaEletronico.DTO
{
    public class TransacoesDTO
    {
        public int ContaDebitadoId { get; set; }
        public string NumeroDaConta { get; set; }
        public string DataDeTransferencia { get; set; }
        public string descricao { get; set; }
        public decimal Valor { get; set; }
        public int ContaCreditadoId { get; set; }
        public string NumeroDaContaCreditado { get; set; }
    }
}