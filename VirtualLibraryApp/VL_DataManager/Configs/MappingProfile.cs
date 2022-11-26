using AutoMapper;
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

        }
    }
}
