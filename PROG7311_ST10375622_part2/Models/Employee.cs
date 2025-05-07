using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PROG7311_ST10375622_part2.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        //validation checks on email to ensure that user enter their email
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Role { get; set; }

        [BindNever]
        [ValidateNever]
        public string UserId { get; set; }
    }
}
