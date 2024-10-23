using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.Data.DTOs
{
    public class UserDTOs
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public string UserType { get; set; } = null!;

        public string? ProfilePictureUrl { get; set; }

        public string? Status { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastLoginDate { get; set; }

    }
}
