namespace caixaEletronico.model
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
    }
}