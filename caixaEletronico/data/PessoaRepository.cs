using System.Threading.Tasks;
using caixaEletronico.model;

namespace caixaEletronico.data
{
    public class PessoaRepository : IPessoaRepository
    {

        public Task<Pessoa[]> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}