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

    public class OutfitRepository : IOutfitRepository
    {
        WardrobeWizard context;

        public OutfitRepository(WardrobeWizard context)
        {
            this.context = context;
        }
        public async Task<int> Create(Outfit entity)
        {
            await context.Outfits.AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var outfit = await context.Outfits.FindAsync(id);

            if (outfit == null)
            {
                return false;
            }

            context.Outfits.Remove(outfit);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Outfit>> GetAll()
        {
            return await context.Outfits
                .Include(outfit => outfit.Items)
                .ToListAsync<Outfit>();
        }

        public async Task<Outfit> GetById(int id)
        {
            return await context.Outfits
                .Include(outfit => outfit.Items)
                .FirstOrDefaultAsync(outfit => outfit.OutfitId == id);
        }
    

        public async Task<int> Update(int id, Outfit entity)
        {
            var outfit = await context.Outfits.FindAsync(id);
            if (outfit == null)
            {
                return 0;
            }

            outfit.Name = entity.Name;
            outfit.Description = entity.Description;
           // outfit.Items = entity.Items;
            return await context.SaveChangesAsync();

        }

        public async Task<Outfit> find(int id)
        {
            Outfit outfit = await context.Outfits.FindAsync(id);
            return outfit;
        }

    }
}
