using System.Threading.Tasks;
using caixaEletronico.model;

namespace caixaEletronico.data
{
    public interface ITipoContaRepository
    {
         Task<TipoConta> GetTipoContaById(int id);
    }
}