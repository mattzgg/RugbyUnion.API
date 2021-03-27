using System.Collections.Generic;

namespace RugbyUnion.API.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ground { get; set; }

        public string Coach { get; set; }

        public int FoundedYear { get; set; }

        public string Region { get; set; }
        public IList<Player> Players { get; set; } = new List<Player>();
    }

}