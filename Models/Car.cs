using System.ComponentModel.DataAnnotations;

namespace CarApplication.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marca este obligatorie")]
        [StringLength(50, ErrorMessage = "Marca nu poate depăși 50 de caractere")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Modelul este obligatoriu")]
        [StringLength(50, ErrorMessage = "Modelul nu poate depăși 50 de caractere")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "Anul este obligatoriu")]
        [Range(1900, 2025, ErrorMessage = "Anul trebuie să fie între 1900 și 2025")]
        public int Year { get; set; }

        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
