using System;
using System.Collections.Generic;

namespace StoreLogic_lib.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int UserId { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string? Apartment { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
