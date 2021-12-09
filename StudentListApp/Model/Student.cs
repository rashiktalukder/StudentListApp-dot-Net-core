using System.ComponentModel.DataAnnotations;

namespace StudentListApp.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Batch { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
