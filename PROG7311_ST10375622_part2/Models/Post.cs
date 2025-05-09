using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PROG7311_ST10375622_part2.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [StringLength (2000)]
        public string Contenet { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string category { get; set; }

        public int FarmerId { get; set; }
        [ForeignKey("FarmerId")]
        [ValidateNever]
        public Farmer Farmer { get; set; }
    }
}
