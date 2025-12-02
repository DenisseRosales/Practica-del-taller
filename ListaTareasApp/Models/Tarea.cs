using System.ComponentModel.DataAnnotations;

namespace ListaTareasApp.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        public bool Completada { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La prioridad es obligatoria")]
        public string Prioridad { get; set; } = "Media";

        public string UsuarioId { get; set; } = string.Empty;
    }
}