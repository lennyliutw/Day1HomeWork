using System;
using System.ComponentModel.DataAnnotations;

namespace Day1HomeWork.Filter
{
    public class BeforeTodayAttribute : ValidationAttribute
    {
        
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var compareDate = value as DateTime?;

            if (compareDate.HasValue)
            {
                compareDate = compareDate.Value.Date;
                return compareDate.Value < DateTime.Today;
            }
            return false;

        }
    }
}