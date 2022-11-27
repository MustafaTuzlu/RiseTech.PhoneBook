using AutoMapper;
using Contact.Data.Entities;

namespace RiseTech.Services.DTO
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<InfoDTO, Info>();
        }
    }
}
