using AppServices.DTO;
using AutoMapper;
using Repositories.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();
            CreateMap<OutfitDTO, Outfit>();
            CreateMap<Outfit, OutfitDTO>();
            CreateMap<MeasurementDTO, Measurement>();
            CreateMap<Measurement, MeasurementDTO>();


            // Additional mappings here...
        }
    }
}
