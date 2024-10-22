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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCatagoryCommand,int>
    {
        private readonly StoreDbContext _db;
        public DeleteCategoryHandler(StoreDbContext db)
        {
            _db = db; 
        }
        public async Task<int> Handle(DeleteCatagoryCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Categories.FirstOrDefault(x => x.CategoryId == request.id);
            if (result == null) 
            {
                return await Task.FromResult(0);

            }
             _db.Categories.Remove(result);
             _db.SaveChangesAsync();
            return  await Task.FromResult(1);
        }
    }
}
