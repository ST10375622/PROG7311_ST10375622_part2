using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PROG7311_ST10375622_part2.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category {  get; set; }

        [Required(ErrorMessage = "Description  is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public int FarmerId { get; set; }

        [ValidateNever]
        public Farmer Farmer { get; set; }

    }
}
