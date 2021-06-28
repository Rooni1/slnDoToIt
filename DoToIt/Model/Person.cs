using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Model
{
    public class Person
    {
        readonly int id;
        string firstName;
        string lastName;
        static int idCounter = 0;
        public static int Counter { get { return idCounter; } }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name can't be empty Please Fill the first name");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name can't be empty Please Fill the last name");
                }
                else
                {
                    lastName = value;
                }
            }
        }
        public Person(string firstName, string lastName) //Constructor
        {
            id = ++idCounter;
            FirstName = firstName;
            LastName = lastName;

        }

    }
}
