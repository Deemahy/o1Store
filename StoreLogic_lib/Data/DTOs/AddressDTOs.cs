using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.Data.DTOs
{
    public class AddressDTOs
    {
        public int AddressId { get; set; }

        public int UserId { get; set; }

        public string StreetAddress { get; set; } = null!;

        public string? Apartment { get; set; }

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string Country { get; set; } = null!;

    }
}
