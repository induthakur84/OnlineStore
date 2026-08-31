using Microsoft.AspNetCore.Mvc;
using Order.Data;
using Order.DTO.Request;
using Order.DTO.Response;
using ProjectCommonCode;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpPost]

        public async Task<ActionResult<UserRequest>> Create(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest();
            }
            var createdUser= await _userInterface.Create(userRequest);

            return Ok(createdUser);
        }

        [HttpGet]
        public async Task<ActionResult<PageResults<UserResponse>>>GetAll(
               int pageNumber = 1,
            int PageSize = 10,
            string? search = null,
            string? sortBy = null,
            string? sortOrder = "desc"
            )
        {
            var users= await _userInterface.GetAll(pageNumber,PageSize,search,sortBy,sortOrder);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task <ActionResult<UserResponse>>GetById(int id)
        {
            var user= await _userInterface.GetById(id);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> Update(int id, UserRequest userRequest)
        {
            if(userRequest == null)
            {
                return BadRequest();
            }
            var updatedUser= await _userInterface.Update(id,userRequest);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userInterface.DeleteById(id);
            return Ok();
        }
    }
}
