using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Model;
using System.Linq;

namespace ToDoIt.Data
{
    public class TodoItems
    {
        //An array that gets filled with Todo items
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

        //Returns an array of items with the matching status
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

        //Returns an array of items with items given to assignee with a certain personid
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

        //Returns An array with items given to a certain  assignee
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

        //Return an array with items without a assigned person to it
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
        
        //Removes an item from the todoArray
        public Todo[] RemoveItem(string descriptionToRemove)
        {
            int indexToBeRemoved = -1;
            for (int i = 0; i < TodoArray.Length; i++)
            {
                if (TodoArray[i].Description.Equals(descriptionToRemove))
                {
                    indexToBeRemoved = i;
                    break;
                }

            }

            if (TodoArray[indexToBeRemoved].Description.Equals(descriptionToRemove))
            {
                int lengthOfArray = Size() - 1;
                if (indexToBeRemoved == TodoArray.Length - 1)
                {
                    Array.Resize(ref TodoArray, lengthOfArray);
                }
                else
                {

                    int testIndex = indexToBeRemoved;
                    indexToBeRemoved = TodoArray.Length - 1;
                    TodoArray[testIndex] = TodoArray[indexToBeRemoved];
                    Array.Resize(ref TodoArray, TodoArray.Length - 1);

                }

            }

            return TodoArray;

        }
        
        //Resizes the inputted array with 1 an inputs an object from the todoArray with the index of I
        public Todo[] ResizedArray(Todo[] whatArray, int i)
        {
            Array.Resize(ref whatArray, whatArray.Length + 1);
            whatArray[whatArray.Length - 1] = TodoArray[i];

            return whatArray;
        }

    }
}















		