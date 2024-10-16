﻿using MediatR;
using StoreLogic_lib.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Command
{
    public record DeleteCatagoryCommand(int id) :IRequest<int>
    {
    }
}
