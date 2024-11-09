using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.Data.DTOs
{
    public class UserDTOs
    {
        public int UserId { get; set; }

        public string ?UserName { get; set; }
        
        public string Password { get; set; }

        public string? Email { get; set; }

        public string Phone { get; set; }

        public string UserType { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string  Status { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime ?LastLoginDate { get; set; }

    }
}
