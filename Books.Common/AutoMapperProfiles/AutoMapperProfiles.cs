using AutoMapper;
using Books.Common.DTO;
using Books.DataAccess.Entities;

namespace Books.Common.AutoMapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Book, BooksDTO>().ReverseMap();

            }
        }
    }
}
