using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Intefaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categorias>> GetAllAsync();
        Task<Categorias> GetByIdAsync(int id);
        Task<Categorias> AddAsync(Categorias categoria);
        Task<Categorias> UpdateAsync(Categorias categoria);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
