﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeesTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
    }
}
