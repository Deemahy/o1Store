using MediatR;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Data.DTOs;
using StoreLogic_lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class UpDataCategoryHandler : IRequestHandler<UpDataCategoryCommand, CategoryDTOs>
    {
        private readonly StoreDbContext _db;
        public UpDataCategoryHandler( StoreDbContext db)
        {
            _db = db;
        }

        public async Task<CategoryDTOs> Handle(UpDataCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Categories.FirstOrDefault(x=>x.CategoryId == request.DTOs.CategoryId);
            if (result == null) {
                return null;
             }
            result.CategoryName = request.DTOs.CategoryName;
            result.Description= request.DTOs.Description;   
            result.ImageUrl = request.DTOs.ImageUrl;

            CategoryDTOs categoryDTOs = new()
            {
                CategoryName = result.CategoryName,
                Description = result.Description,
                ImageUrl = result.ImageUrl

            };
            //How to use auto mapper 
            _db.SaveChangesAsync();
            return categoryDTOs;    
        }
    }
}
