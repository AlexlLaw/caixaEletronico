using System.Linq;
using System.Threading.Tasks;
using CoolMessages.App.Models;
using Microsoft.EntityFrameworkCore;

namespace  CoolMessages.App.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}