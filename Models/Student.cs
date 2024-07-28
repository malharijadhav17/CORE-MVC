using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CORE_MVC.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }

        [Required(ErrorMessage = "Name is Required."), MaxLength(100)]
        public required string SName { get; set; }

        [Required(ErrorMessage = "Contact is Required."), MaxLength(10)]
        public required string SContact { get; set; }

        [MaxLength(300)]
        public string? SAddress { get; set; }

        [Required(ErrorMessage = "Class is Required."), MaxLength(50)]
        public required string SClass { get; set; }

        [Required(ErrorMessage = "Fees is Required."), Precision(16, 2)]
        public required decimal SFees { get; set; }
        
        public string? SProfile { get; set; }
        
        [Required(ErrorMessage = "User is Required."), MaxLength(100)]
        public required string CreatedUser { get; set; }
        
        [MaxLength(100)]
        public string? UpdatedUser { get; set; }
        
        public required DateTime CreatedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
    }
}
