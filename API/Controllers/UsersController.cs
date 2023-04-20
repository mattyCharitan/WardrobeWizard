using Microsoft.AspNetCore.Authentication;
using AppServices.DTO;
using AppServices.Interfaces;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController:WardrobeBaseController
    {
        IUserSer userService;
        IAuthenticationService _authenticationService;

        public UsersController(IUserSer userService, IAuthenticationService authenticationService)
        {
            this.userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Users/GetAll" }, "Google");
            }

            var users = await userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetById([FromRoute] int id)
        {
            return await userService.GetById(id);
        }


        [HttpDelete]
        public async Task<bool>Delete(int id)
        {
            return await userService.Delete(id);
        }

        [HttpPost]

        public async Task<int> Create(UserDTO user)
        {
            return await userService.Create(user);
        }

        [HttpPut]

        public async Task<int>Update(int id, UserDTO user)
        {
            return await userService.Update(id, user);
        }

    }
}
