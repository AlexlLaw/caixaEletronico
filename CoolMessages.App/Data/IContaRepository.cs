using System.Threading.Tasks;
using  CoolMessages.App.Models;

namespace  CoolMessages.App.Data
{
    public interface IContaRepository
    {
         Task<Pessoa[]> GetAll();
         Task<Pessoa> GetByConta(string conta);
         Task<Pessoa> GetByCpf(string cpf);
         Task<Pessoa> GetById(int id);
         Task<Conta> GetContaById(int id);
    }
}