using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.CQRS.Query;
using StoreLogic_lib.Data.DTOs;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator; 
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayment() {


            return Ok(_mediator.Send(new GetAllPaymentQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> AddPayment(PaymentDTOs DTOs)
        {
            return Ok(_mediator.Send(new AddPaymentCommand(DTOs)));
        }
    }
}
