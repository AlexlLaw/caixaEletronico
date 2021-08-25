using System.Threading.Tasks;
using caixaEletronico.DTO;
using caixaEletronico.model;

namespace caixaEletronico.services
{
    public interface IContaService
    {
        Task<Pessoa[]> GetAll();
        Task<Pessoa> GetByCpf(string cpf);
        Task<Pessoa> GetByConta(string conta);
        Task<Pessoa> GetById(int id);
        Task<TipoConta> GetTipoContaById(int id);
        Task<bool> SaveChangesAsync();
        void UpdateConta(Pessoa model);
        void DeleteConta(Pessoa model);
        Task<Conta> GetContaById(int id);
        Pessoa AdicionarConta(PessoaDTO model);
        // void AdicionarConta(Pessoa model);
        bool VerifySaldo(string NumeroDaConta, decimal valorDaTransferencia);
        Pessoa mountPessoa(PessoaDTO model);
    }
}