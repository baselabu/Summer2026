using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Models
{
    public class TaskItem
    {
        private int _id;
        public int Id
        {
            get; set;
        }
        
        public string Title { get; set; } = "";
    }
}