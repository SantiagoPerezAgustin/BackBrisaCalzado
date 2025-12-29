using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categorias>> GetCategoriaAllAsync();
        Task<Categorias> GetCategoriaByIdAsync(int id);
        Task<Categorias> CreateCategoriaAsync(Categorias categoria);
        Task<Categorias> UpdateCategoriaAsync(Categorias categoria);
        Task<bool> DeleteCategoriaAsync(int id);
        Task<bool> ExistsCategoriaAsync(int id);
    }
}
