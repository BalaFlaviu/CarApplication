using System.ComponentModel.DataAnnotations;

namespace CarApplication.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu")]
        [StringLength(100, ErrorMessage = "Numele nu poate depăși 100 de caractere")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Numărul de telefon este obligatoriu")]
        [Phone(ErrorMessage = "Număr de telefon invalid")]
        public string Phone { get; set; } = string.Empty;

        public List<Car>? Cars { get; set; }
    }
}