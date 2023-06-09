using Models.StatusModel;
using Models.UserModel;
using System;
using System.Collections.Generic;

namespace Models.TaskModel
{
    public class TaskInfo
    {
        public int TaskId { get; set; }
        public int? ParentId { get; set; }

        public UserInfo User { get; set; }
        public UserInfo Manager { get; set; }

        public TaskType Type { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int PercentageOfDone { get; set; }

        public StatusInfo Status { get; set; }
        public DateTime Deadline { get; set; }
     
        public List<TaskInfo> Subtasks { get; set; }

        public TaskInfo()
        {
            User = new UserInfo();
            Manager = new UserInfo();
            Type = new TaskType();
            Status = new StatusInfo();
            Subtasks = new List<TaskInfo>();
            
        }
        public TaskInfo(int id)
        {
            TaskId = id;
            User = new UserInfo();
            Manager = new UserInfo();
            Type = new TaskType();
            Status = new StatusInfo();
            Subtasks = new List<TaskInfo>();

        }
    }
}
