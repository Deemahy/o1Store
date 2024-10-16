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
    public class AddCategoryHandler : IRequestHandler<AddCatagoryCommand, CategoryDTOs>
    {
        private readonly StoreDbContext _db;
        public AddCategoryHandler(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<CategoryDTOs> Handle(AddCatagoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new()
            {
                CategoryName = request.DTOs.CategoryName,
                Description = request.DTOs.Description,
                ImageUrl = request.DTOs.ImageUrl
            };
             _db.Categories.Add(category);
              _db.SaveChangesAsync();  
             CategoryDTOs categoryDTOs = new() { 
              CategoryId = request.DTOs.CategoryId, 
              CategoryName = request.DTOs.CategoryName,
              Description = request.DTOs.Description,   
             };    
            return await Task.FromResult(categoryDTOs); 
        }
    }
}
