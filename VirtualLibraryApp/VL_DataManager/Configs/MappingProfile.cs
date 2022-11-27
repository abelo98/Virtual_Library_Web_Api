using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using VL_DataAccess.Models;
using VL_DataManager.Dtos;

namespace VL_DataManager.Configs
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<LibraryUserDtoRequest, LibraryUser>();
            CreateMap<LibraryUser, LibraryUserDtoResponse>();


            CreateMap<Author,AuthorDtoResponse>();
            CreateMap<AuthorDtoRequest, Author>();


            CreateMap<JsonPatchDocument<LibraryUserDtoRequest>, JsonPatchDocument<LibraryUser>>();
            CreateMap<Operation<LibraryUserDtoRequest>, Operation<LibraryUser>>();
        }
    }
}
