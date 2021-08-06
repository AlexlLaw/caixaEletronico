using System;
using caixaEletronico.model;

namespace caixaEletronico.DTO
{
    public class TransacoesDTO
    {
        public int ContaDebitadoId { get; set; }
        public DateTime DataDeTransferencia { get; set; }
        public string descricao { get; set; }
        public decimal Valor { get; set; }
        public int ContaCreditadoId { get; set; }
    }
}