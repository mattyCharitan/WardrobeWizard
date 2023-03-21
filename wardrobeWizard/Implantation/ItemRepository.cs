using Microsoft.EntityFrameworkCore;
using Repositories.DataObjects;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implantation
{
    internal class ItemRepository : IItemRepository
    {
        WardrobeWizard context;

        public ItemRepository(WardrobeWizard context)
        {
            this.context = context;
        }
        public async Task<int> Create(Item entity)
        {
            await context.Items.AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await context.Items.FindAsync(id);

            if (item == null)
            {
                return false;
            }

            context.Items.Remove(item);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Item>> GetAll()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<Item> GetById(int id)
        {
            return await context.Items.FirstOrDefaultAsync(item => item.ItemId == id);
        }

        public async Task<int> Update(int id, Item entity)
        {
            var item = await context.Items.FindAsync(id);
            if (item == null)
            {
                return 0;
            }

            item.Category = entity.Category;
            item.Color = entity.Color;
            item.Style = entity.Style;
            item.Brand = entity.Brand;
            item.Size = entity.Size;
            item.ImageUrl = entity.ImageUrl;
            return await context.SaveChangesAsync();
        }
    }
}
