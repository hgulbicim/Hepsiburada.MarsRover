using System.ComponentModel.DataAnnotations;

namespace Hepsiburada.MarsRover.Entities.Entity
{
    public class Position
    {
        [Required(ErrorMessage = "Enter a valid coordinate between 1 and 100.")]
        [Range(1, 100, ErrorMessage = "Enter a valid coordinate between 1 and 100.")]
        [Display(Name = "X Coordinate")]
        public int X { get; set; }

        [Required(ErrorMessage = "Enter a valid coordinate between 1 and 100.")]
        [Range(1, 100, ErrorMessage = "Enter a valid coordinate between 1 and 100.")]
        [Display(Name = "Y Coordinate")]
        public int Y { get; set; }
    }
}