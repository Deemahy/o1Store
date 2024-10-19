using MediatR;
using Nest;
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
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductDTOs>
    {
        private readonly StoreDbContext _db;
        public AddProductHandler(StoreDbContext db)
        {
            _db = db;
        }

        public Task<ProductDTOs> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var category = _db.Categories.Find(request.DTOs.CategoryId);
            if (category == null)
            {
                throw new DllNotFoundException("Category not found.");
            }

            Product product = new() { 
              
                 ProductName = request.DTOs.ProductName,    
                 Description=request.DTOs.Description,  
                 Price=request.DTOs.Price,
                 StockQuantity=request.DTOs.StockQuantity,
                 ImageUrl=request.DTOs.ImageUrl,    
                 Discount=request.DTOs.Discount,
                 DiscountStartDate=request.DTOs.DiscountStartDate,  
                 DiscountEndDate=request.DTOs.DiscountEndDate,
                 CategoryId = request.DTOs.CategoryId,  
            
            
            }; 

            _db.Products.Add(product);  
            _db.SaveChanges();  
            ProductDTOs productDTOs = new() {


                ProductName = request.DTOs.ProductName,
                Description = request.DTOs.Description,
                Price = request.DTOs.Price,
                StockQuantity = request.DTOs.StockQuantity,
                ImageUrl = request.DTOs.ImageUrl,
                Discount = request.DTOs.Discount,
                DiscountStartDate = request.DTOs.DiscountStartDate,
                DiscountEndDate = request.DTOs.DiscountEndDate,
                CategoryId = request.DTOs.CategoryId,

            };


            return Task.FromResult(productDTOs);    
        }
    }
}
