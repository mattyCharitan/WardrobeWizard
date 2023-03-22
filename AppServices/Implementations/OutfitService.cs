using AppServices.DTO;
using AppServices.Interfaces;
using Repositories.DataObjects;
using Repositories.Implantation;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    internal class OutfitService : IOutfitSer
    {
        IOutfitRepository outfitRepository;

        public OutfitService(IOutfitRepository outfitRepository)
        {
            this.outfitRepository = outfitRepository;
        }
        public async Task<int> Create(OutfitDTO entity)
        {
            Outfit outfit = Mapping.Mapper.Map<Outfit>(entity);
            outfit.UserId = 13;
            return await outfitRepository.Create(outfit);
        }

        public async Task<bool> Delete(int id)
        {
            return await outfitRepository.Delete(id);
        }

        public async Task<List<OutfitDTO>> GetAll()
        {

            List<Outfit> outfits = await outfitRepository.GetAll();
            List<OutfitDTO> outfitsDtos = new List<OutfitDTO>();
            foreach (Outfit outfit in outfits)
            {
                OutfitDTO outfitDTO = Mapping.Mapper.Map<OutfitDTO>(outfit);
                outfitsDtos.Add(outfitDTO);
            }
            return outfitsDtos;

        }

        public async Task<OutfitDTO> GetById(int id)
        {
            Outfit outfit = await outfitRepository.GetById(id);
            return Mapping.Mapper.Map<OutfitDTO>(outfit);
        }

        public async Task<int> Update(int id, OutfitDTO entity)
        {
            Outfit user = await outfitRepository.find(id);
            Outfit outfit = Mapping.Mapper.Map<Outfit>(entity);
            outfit.UserId = user.UserId;
            return await outfitRepository.Update(id, outfit);
        }
    }
}
