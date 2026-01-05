using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetAll()
        {
            var categorias = await _categoriaService.GetCategoriaAllAsync();
            return Ok(categorias);
        }

        // GET: api/categoria/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categorias>> GetById(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        // POST: api/categoria
        [HttpPost]
        public async Task<ActionResult<Categorias>> Create([FromBody] Categorias categoria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _categoriaService.CreateCategoriaAsync(categoria);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/categoria/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Categorias categoria)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != categoria.Id) return BadRequest("El id de la URL debe coincidir con el id del objeto.");

            var exists = await _categoriaService.ExistsCategoriaAsync(id);
            if (!exists) return NotFound();

            await _categoriaService.UpdateCategoriaAsync(categoria);
            return NoContent();
        }

        // DELETE: api/categoria/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _categoriaService.DeleteCategoriaAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
