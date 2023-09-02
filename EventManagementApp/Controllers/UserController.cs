using AutoMapper;
using EventManagementApp.Entities;
using EventManagementApp.Request;
using EventManagementApp.Response;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public UserController(UserService service, IMapper mapper)
        {
            _mapper = mapper;
            _userService = service;
        }

        [HttpPost]
        public async Task<ActionResult<SuccessResponse>> AddUser(AddUser newUser)
        {
            var user = _mapper.Map<User>(newUser);
            var res = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(AddUser), new SuccessResponse(201, res));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();
            var users = _mapper.Map<IEnumerable<UserResponse>>(response);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response == null)
            {
                return BadRequest(new SuccessResponse(404, "user Does not Exist."));
            }
            var user = _mapper.Map<UserResponse>(response);
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessResponse>> UpdateUser(Guid id, AddUser UpdatedUser)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessResponse(404, "user Does not Exist."));
            }
            //update 
            var updated = _mapper.Map(UpdatedUser, response);
            var res = await _userService.UpdateUserAsync(updated);
            return Ok(new SuccessResponse(204, res));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessResponse>> DeleteUser(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response == null)
            {
                return BadRequest(new SuccessResponse(404, "user Does not Exist."));
            }
            //Delete
            var res = await _userService.DeleteUserAsync(response);
            return Ok(new SuccessResponse(204, res));
        }

        [HttpPut("BookEvent")]
        public async Task<ActionResult<SuccessResponse>> BuyCourse(Guid id, BookEvent buy)
        {
            try
            {
                var res = await _userService.BookEvent(buy);
                return Ok(new SuccessResponse(204, res));
            }
            catch (Exception ex)
            {
                return BadRequest(new SuccessResponse(400, ex.Message));
            }
        }
    }
}
