using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace courtesynotes.Models
{
    public class CourseModel
    {
        [Required]
        [MaxLength(length: 16, ErrorMessage = "Course/subject name cannot be more than 16 characters long.")]
        public string Name { get; set; }
    }
}
