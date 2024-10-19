using StoreLogic_lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.Data.DTOs
{
    public class ProductDTOs
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public string? ImageUrl { get; set; }

        public decimal? Discount { get; set; }

        public DateTime? DiscountStartDate { get; set; }

        public DateTime? DiscountEndDate { get; set; }


    }
}
