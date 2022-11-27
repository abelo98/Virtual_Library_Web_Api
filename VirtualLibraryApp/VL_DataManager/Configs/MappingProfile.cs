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
            CreateMap<LibraryUser, LibraryUserDto>();
            CreateMap<LibraryUserDto, LibraryUser>();
            CreateMap<Author,AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<JsonPatchDocument<LibraryUserDto>, JsonPatchDocument<LibraryUser>>();
            CreateMap<Operation<LibraryUserDto>, Operation<LibraryUser>>();
        }
    }
}
