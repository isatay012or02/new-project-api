using AutoMapper;
using System;
using Tasks.Application.Common.Mappings;
using Tasks.Application.Tasks.Commands.UpdateTask;

namespace TasksWebApi.Models
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public Guid ID { get; set; }
        public string NameTask { get; set; }
        public string DiscriptionTask { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.ID,
                    opt => opt.MapFrom(taskDto => taskDto.ID))
                .ForMember(taskCommand => taskCommand.NameTask,
                    opt => opt.MapFrom(taskDto => taskDto.NameTask))
                .ForMember(taskCommand => taskCommand.DiscriptionTask,
                    opt => opt.MapFrom(taskDto => taskDto.DiscriptionTask));
        }
    }
}
