using System.ComponentModel.DataAnnotations;

namespace StudentInfo.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string Phone { get; set; }

        public bool Subscribed { get; set; }
    }
}
