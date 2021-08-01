using System.Linq;
using System.Threading.Tasks;
using caixaEletronico.model;
using Microsoft.EntityFrameworkCore;

namespace caixaEletronico.data
{
    public class TipoContaRepository : ITipoContaRepository
    {
        public DataContext _context { get; }

        public TipoContaRepository(DataContext contex)
        {
            _context = contex;
        }

        public async Task<TipoConta> GetTipoContaById(int id)
        {
            IQueryable<TipoConta> query = _context.TipoContas;

            query = query
                    .AsNoTracking()
                    .OrderBy(tp => tp.Tipo)
                    .Where(tp => tp.TipoContaId == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}