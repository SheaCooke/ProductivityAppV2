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
                Day newDay = new Day();
                TaskModel newTask = new TaskModel
                {
                     Description = addTaskViewModel.Description,
                     Notes = addTaskViewModel.Notes,
                     DateAdded = DateTime.Now,
                     DueDate = addTaskViewModel.DueDate,
                     Priority = addTaskViewModel.Priority,
                     Day = newDay
                 };

                _context.Add(newTask);
                _context.SaveChanges();

                return Redirect("AddTask");
            }

            return View("AddTask", addTaskViewModel);
            
        }


        public IActionResult Completed(int Id)
        {
            Day removed = new Day($"Removed {DateTime.Today.DayOfWeek.ToString()}");

            _context.Tasks.Remove(_context.Tasks.Find(Id));
            _context.Days.Add(removed);
            _context.SaveChanges();

            return Redirect("/User/Index");
        }

        
        public IActionResult Edit(int Id)
        {

            ViewBag.task = _context.Tasks.Find(Id);
            

            AddTaskViewModel addTaskViewModel = new AddTaskViewModel();

            return View(addTaskViewModel);
        }

        [HttpPost]
        public IActionResult EditPost(AddTaskViewModel addTaskViewModel, [FromRoute]int Id)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Where(x => x.Id == Id).ToList().ForEach(x => x.Description = addTaskViewModel.Description);
                _context.Tasks.Where(x => x.Id == Id).ToList().ForEach(x => x.Notes = addTaskViewModel.Notes);
                _context.Tasks.Where(x => x.Id == Id).ToList().ForEach(x => x.DueDate = addTaskViewModel.DueDate);
                _context.Tasks.Where(x => x.Id == Id).ToList().ForEach(x => x.Priority = addTaskViewModel.Priority);

                _context.SaveChanges();
                return Redirect("/User/Index");
            }

            return View(addTaskViewModel);
            
        }

        public IActionResult Charts()
        {
            ViewBag.HighPri = _context.Tasks.Where(x => x.Priority == Priority.High).ToArray();
            ViewBag.LowPri = _context.Tasks.Where(x => x.Priority == Priority.Low).ToArray();
            ViewBag.DataPoints = _context.Tasks.ToArray();

            ViewBag.Monday = _context.Days.Where(x => x.DOW == "Monday").ToArray();
            ViewBag.Tuesday = _context.Days.Where(x => x.DOW == "Tuesday").ToArray();
            ViewBag.Wednesday = _context.Days.Where(x => x.DOW == "Wednesday").ToArray();
            ViewBag.Thursday = _context.Days.Where(x => x.DOW == "Thursday").ToArray();
            ViewBag.Friday = _context.Days.Where(x => x.DOW == "Friday").ToArray();
            ViewBag.Saturday = _context.Days.Where(x => x.DOW == "Saturday").ToArray();
            ViewBag.Sunday = _context.Days.Where(x => x.DOW == "Sunday").ToArray();

            ViewBag.RemovedMon = _context.Days.Where(x => x.DOW.Contains("Removed") && x.DOW.Contains("Monday")).ToArray();
            ViewBag.RemovedTue = _context.Days.Where(x => x.DOW.Contains("Removed") && x.DOW.Contains("Tuesday")).ToArray();
            ViewBag.RemovedWed = _context.Days.Where(x => x.DOW.Contains("Removed") && x.DOW.Contains("Wednesday")).ToArray();
            ViewBag.RemovedThu = _context.Days.Where(x => x.DOW.Contains("Removed") && x.DOW.Contains("Thursday")).ToArray();
            ViewBag.RemovedFri = _context.Days.Where(x => x.DOW.Contains("Removed") && x.DOW.Contains("Friday")).ToArray();
            ViewBag.RemovedSat = _context.Days.Where(x => x.DOW.Contains("Removed") && x.DOW.Contains("Saturday")).ToArray();
            ViewBag.RemovedSun = _context.Days.Where(x => x.DOW.Contains("Removed") && x.DOW.Contains("Sunday")).ToArray();

            return View();
        }



        



    }
}
