using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Intefaces
{
    public interface IProductosRepository
    {
        Task<IEnumerable<Productos>> GetAllAsync();
        Task<Productos> GetByIdAsync(int id);
        Task<IEnumerable<Productos>> GetByCategoriaIdAsync(int categoriaId);
        Task<IEnumerable<Productos>> SearchAsync(string? query);  
        Task<Productos> AddAsync(Productos productos);
        Task<Productos> UpdateAsync(Productos productos);
        Task<Productos> DeleteAsync(int id);
        Task<Productos> ExistsAsync(int id);
    }
}
