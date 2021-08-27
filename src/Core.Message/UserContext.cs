using System;

namespace ShipService.Infrastructure.Core.UserContextProvider
{
    public class UserContext
    {
        public Guid UserId { get; private set; }

        public string Username { get; private set; }

        public string Role { get; private set; }

        internal void SetUserContext(
            Guid userId,
            string username,
            string role)
        {
            this.UserId = userId;
            this.Username = username;
            this.Role = role;
        }
    }
}
