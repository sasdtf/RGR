using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TaskModel
{
    public class TaskType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }

        public TaskType(int id , string name, int version) 
        {
            Id = id;
            Name = name;
            Version = version;
        }
        public TaskType()
        {

        }
    }
}
