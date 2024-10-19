using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.CQRS.Handler;
using StoreLogic_lib.CQRS.Query;
using StoreLogic_lib.Data.DTOs;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public ProductController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct() {
            return Ok(_mediatR.Send(new GetAllProductQuery()));
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetSingleProduct(int id)
        {
            return Ok(_mediatR.Send(new GetSingleProductQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTOs DTOs)
        {
            return Ok(_mediatR.Send(new AddProductCommand(DTOs)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(_mediatR.Send(new DeleteProducdCommand( id)));
        }

        [HttpPut]
        public async Task<IActionResult> UpDateProduct(ProductDTOs DTOs)
        {
            return Ok(_mediatR.Send(new UpDateProductCommand(DTOs)));
        }
    }
}
