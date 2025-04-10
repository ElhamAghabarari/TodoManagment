using AutoMapper;
using TodoManagment.Api.Dtos;
using TodoManagment.Domain;

namespace TodoManagment.Api
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDtoView>();
            CreateMap<UserDtoView, User>();

            CreateMap<User, UserDtoCreate>();
            CreateMap<UserDtoCreate, User>();

            CreateMap<TodoTask, TaskDtoView>();
            CreateMap<TaskDtoView, TodoTask>();

            CreateMap<TodoTask, TaskDtoCreate>();
            CreateMap<TaskDtoCreate, TodoTask>();
        }
    }
}
