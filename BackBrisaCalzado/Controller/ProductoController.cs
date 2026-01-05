using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetAll()
        {
            var productos = await _productoService.GetProductoAllAsync();
            return Ok(productos);
        }

        // GET: api/producto/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Productos>> GetById(int id)
        {
            var producto = await _productoService.GetProductoByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        // GET: api/producto/categoria/{categoriaId}
        [HttpGet("categoria/{categoriaId:int}")]
        public async Task<ActionResult<IEnumerable<Productos>>> GetByCategoria(int categoriaId)
        {
            var productos = await _productoService.GetProductoByCategoriaIdAsync(categoriaId);
            return Ok(productos);
        }

        // GET: api/producto/search?query=texto
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Productos>>> Search([FromQuery] string? query)
        {
            var productos = await _productoService.SearchProductoAsync(query);
            return Ok(productos);
        }

        // POST: api/producto
        [HttpPost]
        public async Task<ActionResult<Productos>> Create([FromBody] Productos producto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _productoService.CreateProductoAsync(producto);

            // Devuelve 201 con la ubicación del nuevo recurso
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/producto/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Productos producto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != producto.Id) return BadRequest("El id de la URL debe coincidir con el id del objeto.");

            var exists = await _productoService.ExistsProductoAsync(id);
            if (!exists) return NotFound();

            await _productoService.UpdateProductoAsync(producto);
            return NoContent();
        }

        // DELETE: api/producto/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.DeleteProductoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
