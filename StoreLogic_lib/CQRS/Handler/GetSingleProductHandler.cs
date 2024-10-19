using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreLogic_lib.CQRS.Query;
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
    public class GetSingleProductHandler : IRequestHandler<GetSingleProductQuery, ProductDTOs>
    {
        private readonly StoreDbContext _db;
        public GetSingleProductHandler(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<ProductDTOs> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            var result = _db.Products.FirstOrDefault(x=>x.ProductId == request.id);
            if (result == null)
            { 
              return await Task.FromResult<ProductDTOs>(null);
            }
            ProductDTOs productDTOs = new()
            {
                ProductId = request.id,
                ProductName = result.ProductName,
                Description = result.Description,
                Price = result.Price,
                StockQuantity = result.StockQuantity,
                CategoryId = result.CategoryId,
                ImageUrl = result.ImageUrl,
                Discount = result.Discount,
                DiscountStartDate = result.DiscountStartDate,
                DiscountEndDate = result.DiscountEndDate,


            };
            return await Task.FromResult(productDTOs);

            
        }
    }
}
