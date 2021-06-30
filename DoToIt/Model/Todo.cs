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
        Person assignee = null;//If it is null, than it means that a Todo item has not been assigned to a assignee

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
        public Person Assignee { get { return assignee; } }

        //Constructor
        public Todo(string description, int todoId)
        {
            this.Description = description;
            this.todoId = todoId;//The todo id will should be given by the TodoSequencer NextTodoId method
        }

        //Assign Todo to Person
        public void AssignPerson(Person person)
        {
            this.assignee = person;
        }

        public override string ToString()
        {
            string status;
            return $"ID: {ToDoId}\nDescription: {Description}\nStatus: {(status = Done == true ? "Done":"Not Finished")}";
        }

        public void TodoStatus(bool status)
        {

            this.done = status;
        }

    }
}
