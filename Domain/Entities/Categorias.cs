using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        // Evita bucles de referencia en la serialización JSON
        [JsonIgnore]
        public ICollection<Productos> Productos { get; set; } = new List<Productos>();
    }
}