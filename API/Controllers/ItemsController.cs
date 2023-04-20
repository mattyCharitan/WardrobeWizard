using AppServices.DTO;
using AppServices.Implementations;
using AppServices.Interfaces;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace API.Controllers
{

    public class ItemsController : WardrobeBaseController
    {
        IItemSer itemService;
        IAuthenticationService _authenticationService;

        public ItemsController(IItemSer itemService, IAuthenticationService authenticationService)
        {
            this.itemService = itemService;
            _authenticationService = authenticationService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Items/GetAll" }, "Google");
            }
            var items = await itemService.GetAll();
            return Ok(items);
        }


        [HttpGet("{id}")]
        public async Task<ItemDTO> GetById(int id)
        {
            return await itemService.GetById(id);
        }
        

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await itemService.Delete(id);
        }
        

        [HttpPut]

        public async Task<int> Create(ItemDTO item)
        {
            return await itemService.Create(item);
        }

        [HttpPost]

        public async Task<int> Update(int id, ItemDTO item)
        {
            return await itemService.Update(id, item);
        }

    }
}
