using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Users;

namespace ProjectV2.API.Controllers
{
    [Route("api/users")]
    public class UserController : AppBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync([FromRoute]int id)
        {
            UserDto userDto = await _userService.GetByIdAsync(id);
            if (userDto is null)
            {
                return BadRequest();
            }
            return Ok(userDto);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var userDtos = await _userService.GetAllAsync();
            return Ok(userDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]UserUpdateDto userUpdateDto)
        {
            UserDto userDto = await _userService.CreateUserAsync(userUpdateDto);
            if (userDto is null)
            {
                return BadRequest();
            }
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute]int id, [FromBody]UserUpdateDto userUpdateDto)
        {
            var userDto = await _userService.GetByIdAsync(id);
            if (userDto is null)
            {
                return BadRequest();
            }
            await _userService.UpdateUserAsync(id, userUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute]int id)
        {
            var userDto = await _userService.GetByIdAsync(id);
            if (userDto is null)
            {
                return BadRequest();
            }
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
