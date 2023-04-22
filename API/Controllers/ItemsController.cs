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
        public async Task<IActionResult> GetById(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Items/GetById" }, "Google");
            }
            var itemById = await itemService.GetById(id);
            return Ok(itemById);
        }
        

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Items/Delete" }, "Google");
            }
            var delete = await itemService.Delete(id);
            return Ok(delete);
        }
        

        [HttpPut]

        public async Task<IActionResult> Create(ItemDTO item)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Items/Create" }, "Google");
            }
            var createItem = await itemService.Create(item);
            return Ok(createItem);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, ItemDTO item)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Items/Update" }, "Google");
            }
            var updateItems = await itemService.Update(id, item);
            return Ok(updateItems);
        }

    }
}
