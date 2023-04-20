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
        public async Task<OutfitDTO> GetById( int id)
        {
            return await outfitService.GetById(id);
        }


        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await outfitService.Delete(id);
        }

        [HttpPost]

        public async Task<int> Create(OutfitDTO outfit)
        {
            return await outfitService.Create(outfit);
        }

        [HttpPut]

        public async Task<int> Update(int id, OutfitDTO outfit)
        {
            return await outfitService.Update(id, outfit);
        }

    }
}
