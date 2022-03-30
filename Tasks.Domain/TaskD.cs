using System;

namespace Tasks.Domain
{
    public class TaskD
    {
        public Guid UserID { get; set; }
        public Guid ID { get; set; }
        public string NameTask { get; set; }
        public string DiscriptionTask { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
