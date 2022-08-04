using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sample.Models;
using Sample.Services;

namespace Sample.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeService _service;
        //private readonly TaskContext _context;

        public EmployeesController(IEmployeeService service)
        {
            //_context = context;
            _service = service;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync().ConfigureAwait(false));
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Employees == null)
            //{
            //    return NotFound();
            //}
            var data = await _service.DetailsAsync(id).ConfigureAwait(false);
            //var employee = await _context.Employees
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            return View(data);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,Address,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                await _service.CreateAsync(employee);


                //  _context.Add(employee);
                //    await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _service.FindByIdAsync(id.Value).ConfigureAwait(false);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Position,Address,Email")] Employee employee)
        {
            //if (id != employee.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            await _service.EditAsync(employee);

            //        _context.Update(employee);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!EmployeeExists(employee.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            return RedirectToAction(nameof(Index));
            //}
            //return View(employee);

        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _service.FindByIdAsync(id.Value).ConfigureAwait(false);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.Employees == null)
            //{
            //    return Problem("Entity set 'TaskContext.Employees'  is null.");
            //}

            await _service.DeleteAsync(id).ConfigureAwait(false);
            //var employee = await _service.FindByIdAsync(id).ConfigureAwait(false);
            //if (employee != null)
            //{
            //    _context.Employees.Remove(employee);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool EmployeeExists(int id)
        //{
        //    return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        //}



    }
}
