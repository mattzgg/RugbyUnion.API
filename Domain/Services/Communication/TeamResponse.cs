using System;
using RugbyUnion.API.Domain.Models;

namespace RugbyUnion.API.Domain.Services.Communication
{
    public class TeamResponse : BaseResponse
    {
        public Team Team { get; private set; }

        private TeamResponse(bool success, string message, Team team) : base(success, message)
        {
            Team = team;
        }

        public TeamResponse(Team team) : this(true, string.Empty, team) { }

        public TeamResponse(string message) : this(false, message, null) { }
    }
}
