using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get { return firstName; }

            set
            {
                ThrowIfNullOrEmpty(value, "first name");
                ThrowIfNotOnlyLetters(value);

                firstName = value;
            }
        }


        public string LastName
        {
            get { return lastName; }
            set 
            {
                ThrowIfNullOrEmpty(value, "last name");
                ThrowIfNotOnlyLetters(value);

                lastName = value; 
            }
        }

        public int Age
        {
            get { return age; }
            set 
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Age)}", "Age should be in the range [0...120]");
                }

                age = value; 
            }
        }

        private static void ThrowIfNullOrEmpty(string value, string parameter)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("name",$"The {parameter} cannot be null or empty");
            }
        }

        private static void ThrowIfNotOnlyLetters(string value)
        {
            if (!value.All(c => char.IsLetter(c)))
            {
                throw new InvalidPersonNameException("The name can only contain characters");
            }
        }
    }
}
