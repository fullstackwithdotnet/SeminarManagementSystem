using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarManagementSystem.Models
{
    public class Attendee
    {
        [Key]
        public int Attendee_Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Phone Number")]
        public string Phone_No { get; set; }
        [Required]
        [Display(Name = "Date of birth")]
        public DateTime Date_Of_Birth { get; set; }
        [Required]
        [MaxLength(128)]
        public string Designation { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string Occupation { get; set; }
        public virtual Seminar Seminar { get; set; }
    }
}
