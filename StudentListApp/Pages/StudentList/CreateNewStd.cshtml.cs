using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentListApp.Model;
using System.Threading.Tasks;

namespace StudentListApp.Pages.StudentList
{
    public class CreateNewStdModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public CreateNewStdModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student student { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Student.AddAsync(student);
                await _db.SaveChangesAsync();
                return RedirectToPage("IndexStudentList");
            }
            else
            {
                return Page();
            }
        }
    }
}
