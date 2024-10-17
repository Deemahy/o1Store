using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StoreLogic_lib.Data.Database;
using MediatR;
using StoreLogic_lib.CQRS.Query;
using StoreLogic_lib.Data.DTOs;
using StoreLogic_lib.CQRS.Command;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediatR;
        public CategoryController(IMediator mediator)
        {
            _mediatR = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategores() {

            return Ok(_mediatR.Send(new GetAllCategoresQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTOs DTOs)
        {

            return Ok(_mediatR.Send(new AddCatagoryCommand(DTOs)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatagory(int id) 
        {

        return Ok(_mediatR.Send(new DeleteCatagoryCommand(id)));
        }

        [HttpPut]
        public async Task<IActionResult> UpDataCatagory(CategoryDTOs DTOs) {
            return Ok(_mediatR.Send(new UpDataCategoryCommand(DTOs)));
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCategory(int id )
        {

            return Ok(_mediatR.Send(new GetSingleCategoryQuery(id)));
        }

    }
}
