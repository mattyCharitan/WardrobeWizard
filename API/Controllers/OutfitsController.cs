using AppServices.DTO;
using AppServices.Implementations;
using AppServices.Interfaces;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.DataObjects;
using Microsoft.AspNetCore.Authentication;


namespace API.Controllers
{
  
    public class OutfitsController : WardrobeBaseController
    {
        IOutfitSer outfitService;
        IAuthenticationService _authenticationService;

        public OutfitsController(IOutfitSer outfitService, IAuthenticationService authenticationService)
        {
            this.outfitService = outfitService;
            _authenticationService = authenticationService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Outfit/GetAll" }, "Google");
            }
            var outfit = await outfitService.GetAll();
            return Ok(outfit);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Outfit/GetById" }, "Google");
            }
            var outfitById = await outfitService.GetById(id);
            return Ok(outfitById);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Outfit/Delete" }, "Google");
            }
            var delete = await outfitService.Delete(id);
            return Ok(delete);
        }

        [HttpPost]

        public async Task<IActionResult> Create(OutfitDTO outfit)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Outfit/Create" }, "Google");
            }
            var create = await outfitService.Create(outfit);
            return Ok(create);
        }

        [HttpPut]

        public async Task<IActionResult> Update(int id, OutfitDTO outfit)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Outfit/Update" }, "Google");
            }
            var update = await outfitService.Update(id, outfit);
            return Ok(update);
        }

    }
}
