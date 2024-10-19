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
    public class DeleteProducdHandler : IRequestHandler<DeleteProducdCommand, int>
    {
        private readonly StoreDbContext _db;
        public DeleteProducdHandler(StoreDbContext db)
        {
            _db = db;
        }

        public Task<int> Handle(DeleteProducdCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Products.FirstOrDefault(x=>x.ProductId== request.id);
            if (result == null) {
              return Task.FromResult(0);    
            }
            _db.Products.Remove(result);
            _db.SaveChanges();
            return Task.FromResult(1);  
            
        }
    }
}
