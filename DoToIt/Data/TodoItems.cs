using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Model;

namespace ToDoIt.Data
{
    public class TodoItems
    {

        private static Todo[] TodoArray = new Todo[0];

        public int Size()
        {
            return TodoArray.Length;
        }

        public Todo[] FindAll()
        {
            return TodoArray;
        }

        //Returns a Todo Id with a specific ID
        public Todo FindById(int todoId)
        {
            Todo sameId = null;//If the inputted Id does not exist, the Todo will be returned as a Null

            foreach (Todo item in TodoArray)
            {
                if (item.ToDoId == todoId)
                {
                    sameId = item;
                    break;
                }
            }
            return sameId;
        }

        //Adds a new Todo item to the TodoArray
        public Todo AddItemToTodoArray(string description)
        {
            Todo newTodo = new Todo(description, TodoSequencer.NextTodoId());

            Array.Resize(ref TodoArray, Size() + 1);

            TodoArray[Size() - 1] = newTodo;

            return newTodo;
        }

        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] statusArray = new Todo[0];

            for (int i = 0; i < TodoArray.Length; i++)
            {

                if (doneStatus == TodoArray[i].Done)
                {
                    statusArray = ResizedArray(statusArray, i);
                }
            }
            return statusArray;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] idAssignArray = new Todo[0];

            for (int i = 0; i < TodoArray.Length; i++)
            {
                if (TodoArray[i].Assignee != null && personId == TodoArray[i].Assignee.PersonId)
                {
                    idAssignArray = ResizedArray(idAssignArray, i);
                }
            }
            return idAssignArray;
        }


        //Removes all the items in the array and gives it a size of zero
        public void Clear()
        {
            Array.Resize(ref TodoArray, 0);
        }
        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] assigneePersonArray = new Todo[0];
            for(int i = 0; i < TodoArray.Length; i++)
            {
                if (TodoArray[i].Assignee != null && TodoArray[i].Assignee == assignee)
                {
                    assigneePersonArray = ResizedArray(assigneePersonArray, i);
                }
            }

            return assigneePersonArray;
        }
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] unassignedToDoItems = new Todo[0];
            
            for (int i = 0; i < TodoArray.Length; i++)
            {
                if (TodoArray[i].Assignee == null)
                {
                    unassignedToDoItems = ResizedArray(unassignedToDoItems, i);
                }
            }
            return unassignedToDoItems;

               
        }

        public Todo[] ResizedArray(Todo[] whichArray, int i)
        {
            Array.Resize(ref whichArray, whichArray.Length + 1);
            whichArray[whichArray.Length - 1] = TodoArray[i];

            return whichArray;
        }
            

    }
}















		