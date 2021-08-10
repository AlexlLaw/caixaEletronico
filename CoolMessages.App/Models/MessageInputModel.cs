using System;

namespace CoolMessages.App.Models
{
    public class MessageInputModel
    {
       
        public int ContaDebitadoId { get; set; }
        public string DataDeTransferencia { get; set; }
        public string descricao { get; set; }
        public decimal Valor { get; set; }
        public int ContaCreditadoId { get; set; }
    }
}
