using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazar.Models.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxIsoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int validationInt = int.Parse(value.ToString());
            bool isDividibleBy100 = validationInt % 100 == 0;

            if (!(200 < validationInt && validationInt < 409600 && isDividibleBy100))
            {  
                return new ValidationResult("The Max ISO must be number in range 200 to 409600 and must be dividable by 100.");
            }

            return ValidationResult.Success;
        }
    }
}
