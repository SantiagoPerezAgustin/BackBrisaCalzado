using System.Collections.Generic;

namespace Domain.Entities
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        // Relación: una categoría puede tener muchos productos
        public ICollection<Productos> Productos { get; set; } = new List<Productos>();
    }
}