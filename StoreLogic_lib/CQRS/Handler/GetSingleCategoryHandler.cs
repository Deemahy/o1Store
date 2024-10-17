using MediatR;
using StoreLogic_lib.CQRS.Query;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class GetSingleCategoryHandler : IRequestHandler<GetSingleCategoryQuery, CategoryDTOs>
    {
        private readonly StoreDbContext _db;
        public GetSingleCategoryHandler( StoreDbContext db)
        {
            _db = db;   
        }

        public Task<CategoryDTOs> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = _db.Categories.FirstOrDefault(x=>x.CategoryId == request.id);
            if (result == null) {
                return Task.FromResult<CategoryDTOs>(null);
            }
            var CategoryDTOs = new CategoryDTOs
            {
                CategoryId = result.CategoryId,    
                CategoryName= result.CategoryName,
                ImageUrl= result.ImageUrl,  
                Description= result.Description


            };
            return Task.FromResult(CategoryDTOs);   

        }
    }
}
