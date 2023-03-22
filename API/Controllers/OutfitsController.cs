using AppServices.DTO;
using AppServices.Implementations;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
    public class OutfitsController : WardrobeBaseController
    {
        IOutfitSer outfitService;

        public OutfitsController(IOutfitSer outfitService)
        {
            this.outfitService = outfitService;
        }

        [HttpGet]

        public async Task<List<OutfitDTO>> GetAll()
        {
            return await outfitService.GetAll();
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
