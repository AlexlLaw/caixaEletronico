using System.Threading.Tasks;
using caixaEletronico.model;

namespace caixaEletronico.data
{
    public interface IContaRepository
    {
         Task<Pessoa[]> GetAll();
         Task<Pessoa> GetByConta(string conta);
         Task<Pessoa> GetByCpf(string cpf);
          Task<Pessoa> GetById(int id);
    }
}