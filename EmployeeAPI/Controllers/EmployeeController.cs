using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers

{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;

        }

        [HttpGet]
        // Get All Items
        public ActionResult<List<EmployeeItem>> GetAll()
        {
            return _context.EmployeeItems.ToList();
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        // Get Item of a specified ID
        public ActionResult<EmployeeItem> GetById(int id)
        {
            var item = _context.EmployeeItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(EmployeeItem item)
        {
            _context.EmployeeItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetEmployee", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeItem item)
        {
            var employee = _context.EmployeeItems.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = item.Name;
            employee.Lastn = item.Lastn;
            employee.Age = item.Age;
            employee.EntryDate = item.EntryDate;
            employee.Area = item.Area;
            employee.Role = item.Role;

            _context.EmployeeItems.Update(employee);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.EmployeeItems.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.EmployeeItems.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}