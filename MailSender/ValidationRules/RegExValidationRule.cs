using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WpfMailSender.ValidationRules
{
    public class RegExValidationRule : ValidationRule
    {
        private Regex regex;

        public string RegExPattern
        {
            get => regex.ToString ();
            set => regex = value is null || value == string.Empty ? null : new Regex ( value );
        }
        public bool AllowNull { get; set; }
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate ( object value, CultureInfo cultureInfo )
        {
            if (value is null) return AllowNull ? ValidationResult.ValidResult : new ValidationResult ( false, "Пустая ссылка" );

            if (regex is null) return ValidationResult.ValidResult;

            if (!(value is string str)) str = value.ToString ();

            return regex.IsMatch ( str ) ? ValidationResult.ValidResult : new ValidationResult ( false, ErrorMessage ?? $"Строка не совпадает с регуляркой {RegExPattern}" );
        }
    }
}
