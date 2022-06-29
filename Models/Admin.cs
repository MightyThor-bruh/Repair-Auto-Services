using System.ComponentModel.DataAnnotations;

namespace AutoService.Models
{
    public class Admin
    {
        [Key]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
