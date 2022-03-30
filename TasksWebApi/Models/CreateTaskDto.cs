using AutoMapper;
using Tasks.Application.Common.Mappings;
using Tasks.Application.Tasks.Commands.CreateTask;
using System.ComponentModel.DataAnnotations;

namespace TasksWebApi.Models
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        [Required]
        public string NameTask { get; set; }
        public string DiscriptionTask { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(taskCommand => taskCommand.NameTask,
                    opt => opt.MapFrom(taskDto => taskDto.NameTask))
                .ForMember(taskCommand => taskCommand.DiscriptionTask,
                    opt => opt.MapFrom(noteDto => noteDto.DiscriptionTask));
        }
    }
}
