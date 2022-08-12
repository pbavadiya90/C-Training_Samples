using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectValidation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ValidationAttribute : Attribute
    {
          public string ErrorMessage { get; set; }
          public abstract bool Validate(object value);
    }
}
