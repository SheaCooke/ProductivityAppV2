using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductivityAppV2.Models;

namespace ProductivityAppV2.ViewModel
{
    public class AddTaskViewModel
    {
        [Required(ErrorMessage ="This field is required.")]
        public string Description { get; set; }

        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }

       
        [Required(ErrorMessage = "This field is required.")]
        public DateTime DueDate { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public Priority Priority { get; set; }


        public List<SelectListItem> PriorityList = new List<SelectListItem>
        {
            new SelectListItem(Priority.High.ToString(), ((int)Priority.High).ToString()),
            new SelectListItem(Priority.Low.ToString(), ((int)Priority.Low).ToString())

        };

        public AddTaskViewModel()
        {
           
        }

        

    }
}
