using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarManagementSystem.Models
{
    public class Type
    {
        [Key]
        public int Type_Id { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string Type_Name { get; set; }
    }
}
