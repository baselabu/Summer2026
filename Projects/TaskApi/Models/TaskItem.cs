using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Models
{
    public class TaskItem
    {
        public int Id
        {
            get; set;
        }
        
        public string Title { get; set; } = "";
        public string Name { get; set; } = "";
    }
}