using AppServices.DTO;
using AppServices.Implementations;
using AppServices.Interfaces;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ItemsController : WardrobeBaseController
    {
        IItemSer itemService;

        public ItemsController(IItemSer itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]

        public async Task<List<ItemDTO>> GetAll()
        {
            return await itemService.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ItemDTO> GetById([FromRoute] int id)
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
