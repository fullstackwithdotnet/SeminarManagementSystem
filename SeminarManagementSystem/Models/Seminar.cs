using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarManagementSystem.Models
{
    public class Seminar
    {
        [Key]
        public int Seminar_Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Seminar Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Seminar Venue")]
        public string Venue { get; set; }
        [Required]
        [Display(Name = "Seminar Date")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Seminar_Date { get; set; }
        [Required]
        [Display(Name = "Seminar Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Starting_Time { get; set; }
        [Required]
        [Display(Name = "Seminar End Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Ending_Time { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual Type Type { get; set; }
        public virtual IEnumerable<Attendee> Attendees { get; set; }

    }
}
