using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool //static olunca bir kere instance olusur hep o kullanılır her yerde
    {
        public static void Validate(IValidator validator,object entity)//statik sınıfın metotlarıda statik olur
        {
            var context = new ValidationContext<object>(entity);
            
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
