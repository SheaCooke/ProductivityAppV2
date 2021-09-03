using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProductivityAppV2.Models;

namespace ProductivityAppV2.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }
        

        public DateTime DueDate { get; set; }

        

        public Priority Priority { get; set; }

        public Day Day { get; set; }
        //public int DayId { get; set; }

        public TaskModel() { }


        public TaskModel(string description, string notes, DateTime dateAdded, DateTime dueDate, Priority priority) :this()
        {
            this.Description = description;
            this.Notes = notes;
            this.DateAdded = dateAdded;
            this.DueDate = dueDate;
            this.Priority = priority;
        }


    }



}
