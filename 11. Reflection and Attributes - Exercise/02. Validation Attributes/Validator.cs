using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                               .GetType()
                .GetProperties();

            foreach (var property in properties)
            {
                Type propertyType = property.PropertyType;
                object[] propertyAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute)
                    .ToArray();
               
                foreach (MyValidationAttribute attribute in propertyAttributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }
    }
}
