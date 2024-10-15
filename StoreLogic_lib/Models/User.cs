using System;
using System.Collections.Generic;

namespace StoreLogic_lib.Models;

public partial class User
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

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
