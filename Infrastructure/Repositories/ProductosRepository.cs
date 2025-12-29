using Domain.Entities;
using Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Productos>> GetAllAsync()
        {
            return _context.Productos.ToList();
        }

        public async Task<Productos> GetByIdAsync(int id)
        {
            return _context.Productos
                .include(p => p.Categoria)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Productos>> GetByCategoriaIdAsync(int categoriaId)
        {
            return await _context.Productos
                .Where(p => p.CategoriaId == categoriaId)
                .Include(p => p.Categoria)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Productos>> SearchAsync(string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAllAsync();

            var q = query.Trim().ToLower();
            return await _context.Productos
                                 .Include(p => p.Categoria)
                                 .Where(p => p.Nombre.ToLower().Contains(q) || p.Descripcion.ToLower().Contains(q))
                                 .AsNoTracking()
                                 .ToListAsync();

        }
        public async Task<Productos> AddAsync(Productos productos)
        {
            await _context.Productos.AddAsync(productos);
            await _context.SaveChangesAsync();
            return productos;
        }
        public async Task<Productos> UpdateAsync(Productos productos)
        {
            _context.Productos.Update(productos);
            await _context.SaveChangesAsync();
            return productos;
        }

        public async Task<Productos> DeleteAsync(int id)
        {
            var existing = await _context.Productos.FindAsync(id);
            if (existing == null) return null;
            _context.Productos.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<Productos> ExistsAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }
    }
}
