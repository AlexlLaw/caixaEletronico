namespace caixaEletronico.DTO
{
    public class PessoaDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public int Idade { get; set; }
        public int TipoContaID { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}