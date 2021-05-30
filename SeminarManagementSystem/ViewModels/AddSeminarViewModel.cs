using Microsoft.AspNetCore.Mvc.Rendering;
using SeminarManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarManagementSystem.ViewModels
{
    public class AddSeminarViewModel
    {
        
        public Seminar  Seminar { get; set; }
        public IList<SelectListItem> Organizers { get; set; }
        [Display(Name ="Organizer")]
        [Required]
        public string SelectedOrganizer { get; set; }
        public IList<SelectListItem> Types { get; set; }
        [Display(Name = "Seminar Type")]
        [Required]
        public string SelectedType { get; set; }
    }
}
