using AutoMapper;

using RepayblApi.Models;

namespace RepayblApi.Core
{
    public static class RepaybMapper
    {
        public static IMapper GetMapper(string baseUrl)
        {
            IConfigurationProvider configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTOs.User, User>();
                cfg.CreateMap<User, DTOs.User>();
                cfg.CreateMap<DTOs.Property, Property>();
                cfg.CreateMap<Property, DTOs.Property>();
                //cfg.CreateMap<Author, DTOs.Author>()
                // .ForMember(x => x.ProfilePic, o => o.MapFrom(x => $"{baseUrl}/api/author/{x.Id}/thumbnail"))
                // .ForMember(x => x.CoverPic, o => o.MapFrom(x => $"{baseUrl}/api/author/{x.Id}/cover"));
                //cfg.CreateMap<DTOs.Author, Author>();

                //cfg.CreateMap<AuthorMedia, DTOs.AuthorMedia>();
                //cfg.CreateMap<DTOs.AuthorMedia, AuthorMedia>();
                //cfg.CreateMap<Interest, DTOs.Interest>();
                //cfg.CreateMap<DTOs.Interest, Interest>();
                //cfg.CreateMap<Post, DTOs.Post>()
                // .ForMember(x => x.CoverPic, o => o.MapFrom(x => $"{baseUrl}/api/blog/{x.Id}/postcover"))
                // .ForMember(x => x.AuthorName, o => o.MapFrom(x => $"{x.Author.FirstName} {x.Author.LastName}"))
                // .ForMember(x => x.AuthorPic, o => o.MapFrom(x => $"{baseUrl}/api/author/{x.AuthorId}/thumbnail"));
                //cfg.CreateMap<DTOs.Post, Post>();
            });
            return new Mapper(configuration);
        }
    }
}
