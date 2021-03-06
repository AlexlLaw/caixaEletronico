using System.ComponentModel.DataAnnotations;

namespace caixaEletronico.model
{
    public class Pessoa
    {
        // public Pessoa(
        //     string nome,
        //     string cpf,
        //     string dataNascimento,
        //     int idade,
        //     int tipoContaID)
        // {
        //     Nome = nome;
        //     Cpf = cpf;
        //     DataNascimento = dataNascimento;
        //     Idade = idade;
        //     TipoContaID = tipoContaID;
        // }

        [Key]
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public int Idade { get; set; }
        public int TipoContaID { get; set; }
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public int? ContaId { get; set; }
        public Conta Conta { get; set; }
    }
}
