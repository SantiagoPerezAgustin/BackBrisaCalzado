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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public Task<IEnumerable<Categorias>> GetCategoriaAllAsync()
        {
            return _categoriaRepository.GetAllAsync();
        }
        public Task<Categorias> GetCategoriaByIdAsync(int id)
        {
            return _categoriaRepository.GetByIdAsync(id);
        }
        public Task<Categorias> CreateCategoriaAsync(Categorias categoria)
        {
            return _categoriaRepository.AddAsync(categoria);
        }
        public Task<Categorias> UpdateCategoriaAsync(Categorias categoria)
        {
            return _categoriaRepository.UpdateAsync(categoria);
        }
        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var existingCategoria = await _categoriaRepository.GetByIdAsync(id);
            if (existingCategoria == null)
            {
                return false;
            }
            await _categoriaRepository.DeleteAsync(id);
            return true;
        }
        public async Task<bool> ExistsCategoriaAsync(int id)
        {
            var existingCategoria = await _categoriaRepository.GetByIdAsync(id);
            return existingCategoria != null;
        }
    }
}
