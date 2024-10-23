using MediatR;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
    {

        private readonly StoreDbContext _db;
        public DeleteUserHandler(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Users.FirstOrDefault(x=>x.UserId== request.id);
            if (result == null) { 
             return  await Task.FromResult(0); 
            }
            _db.Users.Remove(result);
            _db.SaveChanges();
            return await Task.FromResult(1);  
        }
    }
}
