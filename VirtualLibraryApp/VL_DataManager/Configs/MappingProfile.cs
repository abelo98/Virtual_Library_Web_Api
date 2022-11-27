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
            CreateMap<LibraryUser, UserDto>();
            CreateMap<UserDto, LibraryUser>();
            CreateMap<JsonPatchDocument<UserDto>, JsonPatchDocument<LibraryUser>>();
            CreateMap<Operation<UserDto>, Operation<LibraryUser>>();


        }
    }
}
