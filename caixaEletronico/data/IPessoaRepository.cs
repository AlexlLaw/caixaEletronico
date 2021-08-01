using System.Threading.Tasks;
using caixaEletronico.model;

namespace caixaEletronico.data
{
    public interface IPessoaRepository
    {
         Task<Pessoa[]> GetAll(); 
    }
}