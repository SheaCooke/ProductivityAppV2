using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityAppV2.Models
{
    public class Day
    {
        public string DOW { get; set; }

        public List<TaskModel> tasks { get; set; }

        
        public int DayId { get; set; }


        public Day() //Called in view model to add the day a task was added
        {
            this.DOW = DateTime.Today.DayOfWeek.ToString();
        }


        public Day(string removed) // callled when an event is completed 
        {
            this.DOW = removed;
        }

    }
}
