using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceTracker.Data.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } // system-generated

        [Required]
        public int Code { get; set; } // Unique, but not PK

        [Required]
        [RegularExpression(@"^([A-Za-z]{2,}\s){3}[A-Za-z]{2,}$", ErrorMessage = "Full name must be four names, each at least 2 letters.")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        // Navigation
        public Department Department { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
