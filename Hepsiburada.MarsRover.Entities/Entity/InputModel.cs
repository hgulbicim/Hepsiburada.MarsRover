using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hepsiburada.MarsRover.Entities.Entity
{
    public class InputModel
    {
        [Required]
        public Plateau Plateau { get; set; }

        [Required]
        public List<Rover> RoverList { get; set; }
    }
}