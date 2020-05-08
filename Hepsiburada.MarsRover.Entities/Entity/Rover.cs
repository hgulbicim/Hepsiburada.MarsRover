using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hepsiburada.MarsRover.Entities.Entity
{
    public class Rover
    {
        public Guid RoverGuid = Guid.NewGuid();

        public RoverPosition RoverPosition { get; set; }

        [Required]
        [Display(Name = "Discovery Commands")]
        public string CommandParameters { get; set; }

        public List<RoverPosition> RoverPositionHistory { get; set; }
    }
}