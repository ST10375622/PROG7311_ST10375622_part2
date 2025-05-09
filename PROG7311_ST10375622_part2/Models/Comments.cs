using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PROG7311_ST10375622_part2.Models
{
    public class Comments
    {

        [Key]
        public int CommentId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        [ValidateNever]
        public Post Post { get; set; }

        public int FarmerId { get; set; }
        [ForeignKey("FarmerId")]
        [ValidateNever]
        public Farmer Farmer { get; set; }
    }
}
