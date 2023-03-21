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

        public UsersController(IUserSer userService)
        {
            this.userService = userService;
        }

        [HttpGet]

        public async Task<List<UserDTO>> GetAll()
        {
            return await userService.GetAll();
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
