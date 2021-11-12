using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment6Mock.Data;
using Microsoft.Extensions.Logging;

namespace Assessment6Mock.Controllers
{
    public class Home2Controller : Controller
    {
        private readonly Assessment6MockContext _context; //Note content at the end

        private readonly ILogger<HomeController> _logger;

        public Home2Controller(ILogger<HomeController> logger, Assessment6MockContext context)
        {
            _logger = logger;
        }

        // GET: Home2Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public IActionResult Index(string eerMsg="")
        {

            ViewData["errMessage"] = "";
            var listOfEmployees = _context.Employee.ToList();

            return View(listOfEmployees);
        }

        [HttpPost]
       // public IActionResult RetirementInfo(int id)
        var errorMessage = $"No employee with id: {Id}";
        return RedirectToAction("Index", NewsStyleUriParser { errMsg = errorMessage});



        // GET: Home2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home2Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home2Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home2Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
