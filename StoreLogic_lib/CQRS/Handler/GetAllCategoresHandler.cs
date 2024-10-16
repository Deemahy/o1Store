using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreLogic_lib.CQRS.Query;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLogic_lib.Data.DTOs;

namespace StoreLogic_lib.CQRS.Handler
{
    public class GetAllCategoresHandler : IRequestHandler<GetAllCategoresQuery, List<CategoryDTOs>>
    {
        private readonly StoreDbContext _db;
        public GetAllCategoresHandler(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<List<CategoryDTOs>> Handle(GetAllCategoresQuery request, CancellationToken cancellationToken)
        {
            var result = _db.Categories.ToList();
            List<CategoryDTOs> categories = new List<CategoryDTOs>(); //didn't use   
            if (result.Any())
            {
                foreach (var category in result)
                {
                    CategoryDTOs categoryDTO = new()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Description = category.Description,
                        ImageUrl = category.ImageUrl,

                    };

                    categories.Add(categoryDTO);    
                   
                }
                return await Task.FromResult(categories);   
            }
            return (null);
        }
    }
}
