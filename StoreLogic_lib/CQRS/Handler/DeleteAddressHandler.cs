using MediatR;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, int>
    {
        private readonly StoreDbContext _db;
        public DeleteAddressHandler(StoreDbContext db)
        {
            _db = db;
        }
        public Task<int> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Addresses.FirstOrDefault(x => x.AddressId == request.id);
            if (result==null) {
               return Task.FromResult(0);   
            }
             _db.Addresses.Remove(result); 
            _db.SaveChanges();  
            return Task.FromResult(1);  

        }
    }
}
