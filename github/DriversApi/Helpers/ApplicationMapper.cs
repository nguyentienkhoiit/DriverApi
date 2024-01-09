using AutoMapper;
using DriversApi.Models;

namespace DriversApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Driver, DriverDtoRequest>().ReverseMap();
            CreateMap<Driver, DriverDtoResponse>().ReverseMap();
        }
    }
}
