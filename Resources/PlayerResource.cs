using System;

namespace RugbyUnion.API.Resources
{
    public class PlayerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Height in centimeters
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Weight in kilograms
        /// </summary>
        public int Weight { get; set; }

        public string PlaceOfBirth { get; set; }
        public TeamResource Team { get; set; }
    }
}
