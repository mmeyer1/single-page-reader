using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ReadingList.Validators
{
    public class AuthorIsFamousValidator: ValidationAttribute
    {
        public string[] PropertyNames { get; private set; }

      public AuthorIsFamousValidator(params string[] propertyNames)
        {
            this.PropertyNames = propertyNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        var properties = this.PropertyNames.Select(validationContext.ObjectType.GetProperty);
        var values = properties.Select(p => p.GetValue(validationContext.ObjectInstance, null)).OfType<string>();
        var name = values.Single(); 
        // Make API call using name 

        return null; 
        }

    }
}