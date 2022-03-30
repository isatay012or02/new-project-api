using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tasks.Domain;
using Tasks.Application.Common.Mappings;

namespace Tasks.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskVm : IMapWith<TaskD>
    {
        public Guid ID { get; set; }
        public string NameTask { get; set; }
        public string DiscriptionTask { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskD, GetTaskVm>()
                .ForMember(taskVm => taskVm.NameTask,
                    opt => opt.MapFrom(task => task.NameTask))
                .ForMember(taskVm => taskVm.DiscriptionTask,
                    opt => opt.MapFrom(task => task.DiscriptionTask))
                .ForMember(taskVm => taskVm.ID,
                    opt => opt.MapFrom(task => task.ID));
        }
    }
}
