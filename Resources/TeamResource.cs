using System;

namespace RugbyUnion.API.Resources
{
    public class TeamResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ground { get; set; }

        public string Coach { get; set; }

        public int FoundedYear { get; set; }

        public string Region { get; set; }
    }
}
