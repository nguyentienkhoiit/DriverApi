using AutoMapper;
using MongoDb.Data;
using MongoDb.Models;

namespace MongoDb.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Category, CategoryDtoRequest>().ReverseMap();
            CreateMap<Category, CategoryDtoResponse>().ReverseMap();
        }
    }
}
