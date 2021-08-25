using System.Collections.Generic;

namespace caixaEletronico.DTO
{
    public class ContaDTO
    {
        public string NumeroDaConta { get; set; }
        public decimal Saldo { get; set; }
        public bool isAtivo { get; set;}
        public PessoaDTO Pessoa { get; set; }
    }
}