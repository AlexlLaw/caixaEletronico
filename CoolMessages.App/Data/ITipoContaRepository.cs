using System.Threading.Tasks;
using CoolMessages.App.Models;

namespace CoolMessages.App.Data
{
    public interface ITipoContaRepository
    {
         Task<TipoConta> GetTipoContaById(int id);
    }
}