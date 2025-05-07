using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROG7311_ST10375622_part2.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        //validation checks on email to ensure that user enter their email
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string TypeOfFarmer { get; set; }
    }
}
