using AutoMapper;
using KommunensFordon.Models;

namespace KommunensFordon.DTOs
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
        }
    }
}
