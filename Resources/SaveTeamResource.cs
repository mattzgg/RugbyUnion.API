using System;
using System.ComponentModel.DataAnnotations;

namespace RugbyUnion.API.Resources
{
    public class SaveTeamResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string Ground { get; set; }

        [Required]
        public string Coach { get; set; }
        [Required]
        public int FoundedYear { get; set; }
        [Required]
        public string Region { get; set; }
    }
}
