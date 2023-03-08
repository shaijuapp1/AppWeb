

using Application.ToDos;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Todo
            CreateMap<ToDo, ToDo>();

            CreateMap<ToDo, ToDoDto>() 
                .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.AssignedTo
                    .FirstOrDefault(x => x.IsCreatedBy).AppUser.UserName));

            CreateMap<ToDoAssignedTo, Profiles.Profile>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.AppUser.Id))
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio));
        }
    }
}