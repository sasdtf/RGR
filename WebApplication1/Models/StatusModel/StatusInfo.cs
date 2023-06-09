using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.StatusModel
{
    public class StatusInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public StatusInfo()
        {

        }
    }
}
