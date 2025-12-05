using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentFieldsController : ControllerBase
    {
        private readonly studentDbcontext _context;

        public StudentFieldsController(studentDbcontext context)
        {
            _context = context;
        }

        // GET: api/StudentFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentField>>> Getstudents()
        {
            return await _context.students.ToListAsync();
        }

        // GET: api/StudentFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentField>> GetStudentField(int id)
        {
            var studentField = await _context.students.FindAsync(id);

            if (studentField == null)
            {
                return NotFound();
            }

            return studentField;
        }

        // PUT: api/StudentFields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentField(int id, StudentField studentField)
        {
            if (id != studentField.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentFieldExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentFields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentField>> PostStudentField(StudentField studentField)
        {
            _context.students.Add(studentField);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentField", new { id = studentField.Id }, studentField);
        }

        // DELETE: api/StudentFields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentField(int id)
        {
            var studentField = await _context.students.FindAsync(id);
            if (studentField == null)
            {
                return NotFound();
            }

            _context.students.Remove(studentField);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentFieldExists(int id)
        {
            return _context.students.Any(e => e.Id == id);
        }
    }
}
