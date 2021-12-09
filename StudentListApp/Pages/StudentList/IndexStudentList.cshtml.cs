using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentListApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentListApp.Pages.StudentList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public IndexModel(ApplicationDBContext dataBase) //This ApplicationDBContext we are getting by using dependancy injection
        {
            _db = dataBase;
        }
        
        public IEnumerable<Student> Students { get; set; }
        public async Task OnGet()
        {
            Students= await _db.Student.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var stdDelete = await _db.Student.FindAsync(id);
            if (stdDelete == null)
            {
                return NotFound();
            }
            else
            {
                _db.Student.Remove(stdDelete);
                await _db.SaveChangesAsync();
                return RedirectToPage("IndexStudentList");   
            }
        }
    }
}
