using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.Data.DTOs
{
    public class CategoryDTOs
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

    }
}
