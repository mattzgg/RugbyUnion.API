using System;
using RugbyUnion.API.Domain.Models;

namespace RugbyUnion.API.Domain.Services.Communication
{
    public class PlayerResponse : BaseResponse
    {
        public Player Player { get; private set; }

        private PlayerResponse(bool success, string message, Player player) : base(success, message)
        {
            Player = player;
        }

        public PlayerResponse(Player player) : this(true, string.Empty, player) { }

        public PlayerResponse(string message) : this(false, message, null) { }
    }
}
