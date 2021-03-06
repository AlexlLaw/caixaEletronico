using System.Linq;
using System.Threading.Tasks;
using CoolMessages.App.Models;
using Microsoft.EntityFrameworkCore;

namespace  CoolMessages.App.Data
{
    public class ContaRepository : IContaRepository
    {

        public DataContext _context { get; }
        public ContaRepository(DataContext context, DataContext dataContext)
        {
            _context = context;
        }
       public async Task<Pessoa[]> GetAll()
        {
           IQueryable<Pessoa> query = _context.Pessoas;

            query = query   
                    .AsNoTracking()
                    .Include(p => p.Endereco)
                    .Include(p => p.Conta)
                    .OrderBy(p => p.PessoaId);

            return await query.ToArrayAsync();
        }
        public async Task<Pessoa> GetByConta(string conta)
        {
            IQueryable<Pessoa> query = _context.Pessoas;

            query = query   
                    .AsNoTracking()
                    .Include(p => p.Endereco)
                    .Include(p => p.Conta)
                    .Where(p => p.Conta.NumeroDaConta == conta);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa> GetByCpf(string cpf)
        {
             IQueryable<Pessoa> query = _context.Pessoas;

            query = query   
                    .AsNoTracking()
                    .Include(p => p.Endereco)
                    .Include(p => p.Conta)
                    .Where(p => p.Cpf == cpf);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa> GetById(int id)
        {
             IQueryable<Pessoa> query = _context.Pessoas;

            query = query
                    .AsNoTracking()
                    .Include(p => p.Endereco)
                    .Include(p => p.Conta)
                    .Where(p => p.PessoaId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Conta> GetContaById(int id)
        {
             IQueryable<Conta> query = _context.Contas;
             query = query   
                    .AsNoTracking()
                    .Where(c => c.ContaId == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}