﻿using System;
using System.Collections.Generic;

namespace StoreLogic_lib.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal Amount { get; set; }

    public virtual Order Order { get; set; } = null!;
}
