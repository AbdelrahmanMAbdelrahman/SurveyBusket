using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.ValidationAttributeFolder
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MinAgeAttribute(int minAge) : ValidationAttribute
    {
        //    public override bool IsValid(object? value)
        //    {if (value is not null)
        //        {
        //            var date = (DateTime)value;
        //            return DateTime.Today>=date.AddYears(minAge);
        //        }
        //        return false;
        //    }
        protected override ValidationResult IsValid(object? value,ValidationContext context)
        {if (value is not null)
            {
                var date = (DateTime)value;
                return DateTime.Today >= date.AddYears(minAge) ? ValidationResult.Success:
                    new ValidationResult($"validation of {context.DisplayName} can't have value like {value}") ;
            }
            return new ValidationResult($"validation of {context.DisplayName} can't have value like {value}"); ;
        }
    }
}
