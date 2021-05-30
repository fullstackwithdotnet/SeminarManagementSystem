using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarManagementSystem.Models
{
    public class Organizer
    {
        [Key]
        public int Organizer_Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        [Required]
        public int Fees { get; set; }
        [Required]
        [Display(Name = "Signing Date")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Signing_Date { get; set; }
        public virtual IEnumerable<Seminar> Seminars { get; set; }

    }
}
