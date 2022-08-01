using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseLayer
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Range(0, 500000)]

        [Required]
        public long Salary { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
