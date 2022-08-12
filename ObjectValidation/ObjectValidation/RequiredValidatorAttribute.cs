using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectValidation;

namespace ObjectValidationLib
{
    
    public class RequiredValidatorAttribute : ValidationAttribute
    {
        public override bool Validate(object data)
        {
            string _value = data.ToString();
            return string.IsNullOrEmpty(_value);
        }
    }

    public class RangeValidatorAttribute : ValidationAttribute
    {
        public int minValue { get; set; }
        public int maxValue { get; set; }

        public RangeValidatorAttribute(int _minValue, int _maxValue)
        {
            minValue = _minValue;
            maxValue = _maxValue;
        }
        public override bool Validate(object data)
        {
          int Agevalue = Convert.ToInt32(data.ToString()); 
          return  Agevalue >= minValue && Agevalue <= maxValue ? true : false;

        }
    }
    public class LengthValidationAttribute : ValidationAttribute
    {
        int maxLength;
        public LengthValidationAttribute(int maxLengthvalue)
        {
            maxLength = maxLengthvalue;
        }
        public override bool Validate(object value)
        {
            int Lengthvalue = Convert.ToInt32(value.ToString().Length);
            return Lengthvalue <= maxLength ? true : false;
        }
    }
}