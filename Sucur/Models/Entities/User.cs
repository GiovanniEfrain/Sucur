using System.ComponentModel.DataAnnotations;

namespace Sucur.Models.Entities
{
    public class User
    {
        [Key]
        public Guid IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
    }
}
