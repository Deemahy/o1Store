using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery,List< ProductDTOs>>
    {
        private readonly StoreDbContext _db;    
        public GetAllProductHandler(StoreDbContext db)
        {
            _db = db;
        }

        

        async Task<List<ProductDTOs>> IRequestHandler<GetAllProductQuery, List<ProductDTOs>>.Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var result = _db.Products.ToList();
            List<ProductDTOs> productDTOs = new List<ProductDTOs>();
            if (result == null)
            { return await Task.FromResult<List<ProductDTOs>>(null); }
            foreach (var product in result)
            {
                ProductDTOs products = new()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    CategoryId = product.CategoryId,
                    ImageUrl = product.ImageUrl,
                    Discount = product.Discount,
                    DiscountStartDate = product.DiscountStartDate,
                    DiscountEndDate = product.DiscountEndDate
                };
                productDTOs.Add(products);

            }
            return await Task.FromResult(productDTOs);
        }
    }
}
