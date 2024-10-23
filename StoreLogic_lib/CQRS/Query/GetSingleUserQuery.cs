using MediatR;
using StoreLogic_lib.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Query
{
    public record GetSingleUserQuery(int id):IRequest<UserDTOs>
    {
    }
}
