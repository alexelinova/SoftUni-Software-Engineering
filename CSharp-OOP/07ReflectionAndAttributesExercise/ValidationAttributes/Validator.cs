﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes()
                      .Cast<MyValidationAttribute>()
                      .ToArray();

                object value = property.GetValue(obj);

                foreach (var attribute in attributes)
                {
                   bool isValid = attribute.IsValid(value);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
