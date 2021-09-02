using Microsoft.AspNetCore.Mvc;
using ProductivityAppV2.Data;
using ProductivityAppV2.Models;
using ProductivityAppV2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityAppV2.Controllers
{
    public class UserController : Controller
    {
        private TaskDbContext _context;

        public UserController(TaskDbContext dbContext)
        {
            this._context = dbContext;
        }





        public IActionResult Index()
        {
            List<TaskModel> Tasks = _context.Tasks.ToList();// Pass a list made from the MySql table items to the view so that they can be displayed 

            return View(Tasks);
        }


        [HttpGet]
        public IActionResult AddTask()
        {
            AddTaskViewModel addTaskViewModel = new AddTaskViewModel();
            return View(addTaskViewModel);
        }



        [HttpPost]
        public IActionResult AddTaskPost(AddTaskViewModel addTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                TaskModel newTask = new TaskModel
                {
                     Description = addTaskViewModel.Description,
                     Notes = addTaskViewModel.Notes,
                     DateAdded = DateTime.Now,
                     DueDate = addTaskViewModel.DueDate,
                     Priority = addTaskViewModel.Priority
                 };

                _context.Add(newTask);
                _context.SaveChanges();

                return Redirect("AddTask");
            }

            return View("AddTask", addTaskViewModel);




            
        }






    }
}
