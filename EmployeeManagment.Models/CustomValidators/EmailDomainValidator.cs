using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagment.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationcontext)
        {
            string[] strings = value.ToString().Split('@');
        if (strings.Length > 1 && strings[1].ToUpper() == AllowedDomain.ToUpper())
            {
                return null;
            
            }

            return new ValidationResult(ErrorMessage, new[] { validationcontext.MemberName });


        }

    }
}
