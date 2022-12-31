using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CompanyApp.ViewModel
{
    public class CompanyValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueToValidate = value as string;

            if (string.IsNullOrEmpty(valueToValidate))
            {
                return new ValidationResult(false, "Поле не может быть пустым");
            }

            return new ValidationResult(true,null);
        }
    }
}
