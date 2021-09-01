using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductivityAppV2.Models

namespace ProductivityAppV2.Models
{
    public class Task
    {
        public string Description { get; set; }

        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateCompleted { get; set; }

        public DateTime DueDate { get; set; }

        public int Id { get; set; }

        public Priority Priority { get; set; }

        public Task() { }


        public Task(string description, string notes, DateTime dateAdded, DateTime dateCompleted, DateTime dueDate, Priority priority) :this()
        {
            this.Description = description;
            this.Notes = notes;
            this.DateAdded = dateAdded;
            this.DateCompleted = dateCompleted;
            this.DueDate = dueDate;
            this.Priority = priority;
        }
    }



}
