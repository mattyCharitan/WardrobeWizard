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
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Users/GetById" }, "Google");
            }
            var userById = await userService.GetById(id);
            return Ok(userById);
        }


        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Users/Delete" }, "Google");
            }
            var deleteUser = await userService.Delete(id);
            return Ok(deleteUser);
        }

        [HttpPost]

        public async Task<IActionResult> Create(UserDTO user)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Users/Create" }, "Google");
            }
            var createUser = await userService.Create(user);
            return Ok(createUser);
        }

        [HttpPut]

        public async Task<IActionResult> Update(int id, UserDTO user)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Users/Update" }, "Google");
            }
            var updateUser = await userService.Update(id, user);
            return Ok(updateUser);
        }

    }
}
