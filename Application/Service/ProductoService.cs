using Application.Interfaces;
using Domain.Entities;
using Domain.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductosRepository _productoRepository;

        public ProductoService(IProductosRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public Task<IEnumerable<Productos>> GetProductoAllAsync()
        {
            return _productoRepository.GetAllAsync();
        }
        public Task<Productos> GetProductoByIdAsync(int id)
        {
            return _productoRepository.GetByIdAsync(id);
        }
        public Task<IEnumerable<Productos>> GetProductoByCategoriaIdAsync(int categoriaId)
        {
            return _productoRepository.GetByCategoriaIdAsync(categoriaId);
        }
       
        public Task<IEnumerable<Productos>> SearchProductoAsync(string? query)
        {
            return _productoRepository.SearchAsync(query);
        }
        public Task<Productos> CreateProductoAsync(Productos producto)
        {
            return _productoRepository.AddAsync(producto);
        }
        public Task<Productos> UpdateProductoAsync(Productos producto)
        {
            return _productoRepository.UpdateAsync(producto);
        }
        public async Task<bool> DeleteProductoAsync(int id)
        {
            var existingProducto = await _productoRepository.GetByIdAsync(id);
            if (existingProducto == null)
            {
                return false;
            }
            await _productoRepository.DeleteAsync(id);
            return true;
        }
        public async Task<bool> ExistsProductoAsync(int id)
        {
            var existingProducto = await _productoRepository.GetByIdAsync(id);
            return existingProducto != null;
        }
    }
}
