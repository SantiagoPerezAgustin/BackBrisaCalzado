using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<Productos>> GetProductoAllAsync();
        Task<Productos> GetProductoByIdAsync(int id);
        Task<IEnumerable<Productos>> GetProductoByCategoriaIdAsync(int categoriaId);
        Task<IEnumerable<Productos>> SearchProductoAsync(string? query);
        Task<Productos> CreateProductoAsync(Productos producto);
        Task<Productos> UpdateProductoAsync(Productos producto);
        Task<bool> DeleteProductoAsync(int id);
        Task<bool> ExistsProductoAsync(int id);
    }
}
