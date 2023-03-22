
using Application.ToDos;
using AutoMapper;
using Domain;
using Application.AppConfigTypes;
using Application.AppConfigs;
using Application.TableNames;
using Application.TableFields;
using Application.DataSecuritys;
using Application.UserManagers;
using Application.RoleMasters;
using Microsoft.AspNetCore.Identity;

//##MappingUsing##

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
                        		    						
			CreateMap<AppConfigType, AppConfigType>(); 
			CreateMap<AppConfigType, AppConfigTypeDto>();

            CreateMap<AppConfig, AppConfig>(); 
			CreateMap<AppConfig, AppConfigDto>();

            CreateMap<AppConfig, AppConfig>(); 
			CreateMap<AppConfig, AppConfigDto>();

            CreateMap<TableName, TableName>(); 
			CreateMap<TableName, TableNameDto>();

            CreateMap<TableField, TableField>(); 
			CreateMap<TableField, TableFieldDto>();

            CreateMap<DataSecurity, DataSecurity>(); 
			CreateMap<DataSecurity, DataSecurityDto>();

            CreateMap<AppUser, AppUser>(); 
			CreateMap<AppUser, UserManagerDto>();

            CreateMap <IdentityRole, RoleMasterDto>();
            //CreateMap <AppUser, GroupUserDTO>();

            CreateMap <AppUser, GroupUserDTO>();

			//##MappingProfile#    
			
        }
    }
}















