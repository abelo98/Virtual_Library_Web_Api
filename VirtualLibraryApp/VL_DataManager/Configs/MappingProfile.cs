using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Services_Layer.Models;
using VL_DataAccess.Models;
using VL_DataManager.Dtos;

namespace VL_DataManager.Configs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryUserDtoRequest, LibraryUser>();
            CreateMap<LibraryUser, LibraryUserDtoResponse>();
            CreateMap<AllUsers, AllUsersDto>();

            CreateMap<AuthorDtoRequest, Author>();
            CreateMap<Author, AuthorDtoResponse>();

            CreateMap<BookDtoRequest, Book>();
            CreateMap<Book, BookDtoResponse>();

            CreateMap<GetAllBooksQueryFilter, GetAllBooksFilter>();
            CreateMap<BookServiceModel, BookDtoResponse>();



            CreateMap<JsonPatchDocument<LibraryUserDtoRequest>, JsonPatchDocument<LibraryUser>>();
            CreateMap<Operation<LibraryUserDtoRequest>, Operation<LibraryUser>>();
        }
    }
}
