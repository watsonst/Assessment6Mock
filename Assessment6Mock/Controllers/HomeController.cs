using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment6Mock.Data;
using Assessment6Mock.Models;

namespace Assessment6Mock.Controllers
{
    public class HomeController : Controller
    {
        private readonly Assessment6MockContext _context;

        public HomeController(Assessment6MockContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Employees()
        {
            return View(await _context.Employee.ToListAsync());
        }
        
        [HttpPost]
        public IActionResult RetirementInfo(int Id)
        {
            var SearchResult = _context.Employee.Where(T => T.Id == Id).ToList();

            var item = SearchResult.ElementAt(0);


            if (item.Age > 60)
            {
                ViewBag.CanRetire = true;

            }
            else
            {
                ViewBag.CanRetire = false;
            }

            decimal benefits = item.Salary / 100 * 60;

            ViewBag.Benefits = benefits;
            return View("RetirementInfo", SearchResult);


            var employee = _context.Employee.FirstOrDefault(e => e.Id == Id); //because we know the id is unique we can use this because there is only one that will match our predicate. Default is null/0
            
            if (employee == null)
            {
                
                return RedirectToAction("Index");
            }

            ViewBag.CanRetire = employee.Age > 60;

            //ViewBag.CanRetire = employee.Age > 60 ? true : false; Option 1

            //if (employee.Age > 60) //Option 2
            //{
            //    ViewBag.CanRetire = true;

            //}
            //else
            //{
            //    ViewBag.CanRetire = false;
            //}

            ViewBag.Benefits = employee.Salary * .6M;




        }




    }



        // GET: Home/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employee
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        //// GET: Home/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Home/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,Age,Salary")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(employee);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(employee);
        //}

        //// GET: Home/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employee.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee);
        //}

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Age,Salary")] Employee employee)
        //        {
        //            if (id != employee.Id)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(employee);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!EmployeeExists(employee.Id))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(employee);
        //        }

        //        // GET: Home/Delete/5
        //        public async Task<IActionResult> Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var employee = await _context.Employee
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (employee == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(employee);
        //        }

        //        // POST: Home/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(int id)
        //        {
        //            var employee = await _context.Employee.FindAsync(id);
        //            _context.Employee.Remove(employee);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool EmployeeExists(int id)
        //        {
        //            return _context.Employee.Any(e => e.Id == id);
        //        }
    }
}
