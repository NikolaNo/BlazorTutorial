using EmployeeManagment.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagment.Models
{
    public class EditEmployeeModel
    {

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public int? Departmentid { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; } = new Department();


    }
}
