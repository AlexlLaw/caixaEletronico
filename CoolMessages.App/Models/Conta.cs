using System.Collections.Generic;

namespace CoolMessages.App.Models
{
    public class Conta
    {
        public int ContaId { get; set; }
        public string NumeroDaConta { get; set; }
        public decimal Saldo { get; set; }
        public bool isAtivo { get; set;}
        public Pessoa Pessoa { get; set; }
        public  List<Transferecia> Transferencias { get; set; }
    }
}