using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Command
{
    public record DeleteUserCommand(int id ) :IRequest<int>
    {
    }
}
