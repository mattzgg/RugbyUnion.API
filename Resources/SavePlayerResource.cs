using System;
using System.ComponentModel.DataAnnotations;

namespace RugbyUnion.API.Resources
{
    public class SavePlayerResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Height in centimeters
        /// </summary>
        [Required]
        public int Height { get; set; }

        /// <summary>
        /// Weight in kilograms
        /// </summary>
        [Required]
        public int Weight { get; set; }
        [Required]
        public string PlaceOfBirth { get; set; }
    }
}
