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
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses() {
            return Ok(_mediator.Send(new GetAllAddressesQuery()));
        }

        [HttpPost]

        public async Task<IActionResult> AddAddress(AddressDTOs DTOs)
        {


            return Ok(_mediator.Send(new AddAddressCommand(DTOs)));
        }

        [HttpPut]

        public async Task<IActionResult> UpDateAddress(AddressDTOs DTOs)
        {
            return Ok(_mediator.Send(new UpDateAddressCommand(DTOs)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id )
        {



            return Ok(_mediator.Send(new DeleteAddressCommand(id)));
        }
       

    }
}
