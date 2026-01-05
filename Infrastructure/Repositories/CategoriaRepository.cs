using Domain.Entities;
using Domain.Intefaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _context.Categorias
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Categorias> GetByIdAsync(int id)
        {
            return await _context.Categorias
                                 .Include(c => c.Productos)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Categorias> AddAsync(Categorias categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categorias> UpdateAsync(Categorias categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Categorias.FindAsync(id);
            if (existing == null) return false;

            _context.Categorias.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categorias.AnyAsync(c => c.Id == id);
        }
    }
}