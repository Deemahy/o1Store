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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public UserController(IMediator mediator)
        {
            _mediatR = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            return Ok(_mediatR.Send(new GetAllUsersQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            return Ok(_mediatR.Send(new GetSingleUserQuery(id)));
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTOs DTOs)
        {
            return Ok(_mediatR.Send(new AddUserCommand(DTOs)));
        }
        [HttpPut]
        public async Task<IActionResult> UpDateUser(UserDTOs DTOs)
        {
            return Ok(_mediatR.Send(new UpDateUserCommand(DTOs)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id )
        {

            return Ok(_mediatR.Send(new DeleteUserCommand(id)));
        }
    }
}
