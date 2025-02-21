using System.ComponentModel.DataAnnotations;

namespace CarApplication.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Data service-ului este obligatorie")]
        [Display(Name = "Data Service")]
        [DataType(DataType.Date)]
        public DateTime ServiceDate { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        [StringLength(500, ErrorMessage = "Descrierea nu poate depăși 500 de caractere")]
        [Display(Name = "Descriere")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mașina este obligatorie")]
        [Display(Name = "Mașină")]
        public int CarId { get; set; }

        public Car? Car { get; set; }
    }
}