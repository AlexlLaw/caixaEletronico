using System.Threading.Tasks;
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
        string AdicionarConta(Pessoa model);
        void UpdateConta(Pessoa model);
        string DeleteConta(int id);
    }
}