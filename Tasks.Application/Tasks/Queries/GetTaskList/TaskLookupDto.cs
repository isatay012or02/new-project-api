using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tasks.Application.Common.Mappings;
using Tasks.Domain;

namespace Tasks.Application.Tasks.Queries.GetTaskList
{
    public class TaskLookupDto : IMapWith<TaskD>
    {
        public Guid ID { get; set; }
        public string NameTask { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskD, TaskLookupDto>()
                .ForMember(taskDto => taskDto.ID,
                    opt => opt.MapFrom(task => task.ID))
                .ForMember(taskDto => taskDto.NameTask,
                    opt => opt.MapFrom(task => task.NameTask));
        }
    }
}
