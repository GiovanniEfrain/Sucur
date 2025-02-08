using System.ComponentModel.DataAnnotations;

namespace Sucur.Models
{
    public class UserViewModel
    {
        [Key]
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
    }
}
