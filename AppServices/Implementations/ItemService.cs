using AppServices.DTO;
using AppServices.Interfaces;
using Repositories.DataObjects;
using Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    public class ItemService : IItemSer
    {
        IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<int> Create(ItemDTO entity)
        {
            Item item = Mapping.Mapper.Map<Item>(entity);
            item.UserId = 10;
            return await itemRepository.Create(item);
        }

        public async Task<bool> Delete(int id)
        {
            return await itemRepository.Delete(id);
        }

        public async Task<List<ItemDTO>> GetAll()
        {
            List<Item> items = await itemRepository.GetAll();
            List<ItemDTO> itemsDtos = new List<ItemDTO>();
            foreach (Item item in items)
            {
                ItemDTO itemDTO = Mapping.Mapper.Map<ItemDTO>(item);
                itemsDtos.Add(itemDTO);
            }
            return itemsDtos;


        }

        public async Task<ItemDTO> GetById(int id)
        {
            Item item = await itemRepository.GetById(id);
            ItemDTO itemDTO = Mapping.Mapper.Map<ItemDTO>(item);
            return itemDTO;
        }

        public async Task<int> Update(int id, ItemDTO entity)
        {
            Item item = Mapping.Mapper.Map<Item>(entity);
            //check how should i get the missing pieces of the object
            item.UserId = 11; 
            return await itemRepository.Update(id, item);
        }
    }
}
