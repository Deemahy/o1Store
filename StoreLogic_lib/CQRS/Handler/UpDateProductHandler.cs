using MediatR;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class UpDateProductHandler : IRequestHandler<UpDateProductCommand, ProductDTOs>
    {

        private readonly StoreDbContext _db;
        public UpDateProductHandler(StoreDbContext db)
        {
            _db = db;
        }
        public Task<ProductDTOs> Handle(UpDateProductCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Products.FirstOrDefault(x=>x.ProductId == request.DTOs.ProductId);
            var category = _db.Categories.Find(request.DTOs.CategoryId);
            if (result == null)
            {
                throw new Exception("Not found");


            }
            else { 
            if (category == null)
            {
                throw new Exception("Category is not found you cant edit it ");
            }
            else {
                result.ProductName = request.DTOs.ProductName;
                result.Description = request.DTOs.Description;
                result.Price = request.DTOs.Price;
                result.StockQuantity = request.DTOs.StockQuantity;
                result.ImageUrl = request.DTOs.ImageUrl;
                result.Discount = request.DTOs.Discount;    
                result.DiscountStartDate = request.DTOs.DiscountStartDate;
                result.DiscountEndDate = request.DTOs.DiscountEndDate;
                result.CategoryId = request.DTOs.CategoryId;    
                _db.SaveChanges();
            }  
            }
            ProductDTOs productDTOs = new()
            {


                ProductName = request.DTOs.ProductName,
                Description = request.DTOs.Description,
                Price = request.DTOs.Price,
                StockQuantity = request.DTOs.StockQuantity,
                ImageUrl = request.DTOs.ImageUrl,
                DiscountStartDate = request.DTOs.DiscountStartDate,
                DiscountEndDate = request.DTOs.DiscountEndDate,
                CategoryId = request.DTOs.CategoryId,
                Discount = request.DTOs.Discount,

            };
            return Task.FromResult(productDTOs);
        }
    }
}
