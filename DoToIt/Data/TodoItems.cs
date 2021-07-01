using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Model;
using System.Linq;

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
                    Array.Resize(ref statusArray, statusArray.Length + 1);
                    statusArray[statusArray.Length - 1] = TodoArray[i];
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
                    Array.Resize(ref idAssignArray, idAssignArray.Length + 1);
                    idAssignArray[idAssignArray.Length - 1] = TodoArray[i];
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
                    Array.Resize(ref assigneePersonArray, assigneePersonArray.Length + 1);
                    assigneePersonArray[assigneePersonArray.Length - 1] = TodoArray[i];
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
                    Array.Resize(ref unassignedToDoItems, unassignedToDoItems.Length + 1);
                    unassignedToDoItems[unassignedToDoItems.Length - 1] = TodoArray[i];
                }
            }
            return unassignedToDoItems;

                      
        }
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

            if(TodoArray[indexToBeRemoved].Description.Equals(descriptionToRemove))
            {
                int lengthOfArray = Size()-1;
                if(indexToBeRemoved == TodoArray.Length-1)
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







    }
}















		