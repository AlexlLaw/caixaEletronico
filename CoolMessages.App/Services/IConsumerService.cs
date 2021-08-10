using CoolMessages.App.Models;
using System.Threading.Tasks;

namespace CoolMessages.App.Services
{
    public interface IConsumerService
    {
        Transferecia MontarTransferencia(MessageInputModel model);
        void addTransferencia(MessageInputModel model);
    }
}