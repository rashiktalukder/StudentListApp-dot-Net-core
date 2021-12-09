using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentListApp.Model;
using System.Threading.Tasks;

namespace StudentListApp.Pages.StudentList
{
    public class EditStdInfoModel : PageModel
    {
        private ApplicationDBContext _db;

        
        public EditStdInfoModel(ApplicationDBContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        public Student studentEdit { get; set; }    
        public async Task OnGet(int id)
        {
            studentEdit=await _db.Student.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var StdFromDb = await _db.Student.FindAsync(studentEdit.Id);
                StdFromDb.Name = studentEdit.Name;  
                StdFromDb.Batch=studentEdit.Batch;  
                StdFromDb.Email=studentEdit.Email;

                await _db.SaveChangesAsync();
                return RedirectToPage("IndexStudentList");
            }
            return RedirectToPage();
        }
    }
}
