using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Model
{
    public class Todo
    {
        //Private Fields
        private readonly int todoId;// Can only be set once, then the object will not be able to change its unique todoId;
        private string description;
        private bool done;
        Person assignee;

        //Public Properties
        public int ToDoId { get { return todoId; } }
        public bool Done { get { return done; } }
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Description cannot be empty. Please fill in a description.");
                }
                else
                {
                    description = value;
                }

            }
        }

        //Constructor
        public Todo(string description, int todoId)
        {
            this.Description = description;
            this.todoId = todoId;
        }

        //Assign Todo to Person
        public void AssignPerson(Person person)
        {
            this.assignee = person;
        }

    }
}
