using CoolMessages.App.Models;
using System.Threading.Tasks;

namespace CoolMessages.App.Services
{
    public interface IConsumerService
    {
        Task<bool> SaveChangesAsync();
        Transferecia MontarTransferencia(MessageInputModel model);
        void addTransferencia(MessageInputModel model);
        Task<Conta> GetContaById(int id);
        Task<Pessoa> GetByCpf(string cpf);
    }
}