using System.ComponentModel.DataAnnotations;

namespace CarShop.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string MotorFuel { get; set; }
        [Required]
        public string GearBox { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public long Mileage { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Path { get; set; }
        
    }
}
