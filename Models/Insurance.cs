using System.ComponentModel.DataAnnotations;

namespace CarApplication.Models
{
    public class Insurance
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipul asigurării este obligatoriu")]
        [StringLength(50, ErrorMessage = "Tipul asigurării nu poate depăși 50 de caractere")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data de început este obligatorie")]
        [Display(Name = "Data Început")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Data de sfârșit este obligatorie")]
        [Display(Name = "Data Sfârșit")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Mașina este obligatorie")]
        [Display(Name = "Mașină")]
        public int CarId { get; set; }

        public Car? Car { get; set; }
    }
}