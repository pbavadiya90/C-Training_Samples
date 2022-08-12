using System;
using ObjectValidationLib;


namespace ObjectValidation
{
    public class PatientDataModel
    {
        [ObjectValidationLib.RequiredValidator(ErrorMessage ="MRN cannot be empty")]
        public string MRN { get; set; }

        [ObjectValidationLib.LengthValidation(15,ErrorMessage ="Name should have maximum 15 char")]
        public string Name { get; set; }

        [ObjectValidationLib.RangeValidator(1,100,ErrorMessage ="It shoud be within 1 to 100")]
        public int Age { get; set; }
    }
}
