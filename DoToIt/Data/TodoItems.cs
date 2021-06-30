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

            Array.Resize(ref TodoArray, Size()+1);

            TodoArray[Size() - 1] = newTodo;

            return newTodo;
        }

		//Removes all the items in the array and gives it a size of zero
        public void Clear()
        {
            Array.Resize(ref TodoArray, 0);  
        }


		//New Code


		//public Todo[] FindByDoneStatus(bool doneStatus)
		//{
		//	Todo[] NewTodoArray = new Todo[0];

		//	for (int i = 0; i < Size(); i++)
		//	{
		//		if (doneStatus == TodoArray[i].Done)
		//		{
		//			Array.Resize(ref NewTodoArray, NewTodoArray.Length + 1);
		//			NewTodoArray[NewTodoArray.Length - 1] = TodoArray[i];
		//		}
		//	}
		//	return NewTodoArray;
		//}

		//public Todo[] FindByAssignee(int personId)
		//{
		//	Todo[] assigneeTodoArray = new Todo[0];

		//	for (int i = 0; i < Size(); i++)
		//	{
		//		if (TodoArray[i].Assignee != null && TodoArray[i].Assignee.PersonId == personId)
		//		{
		//			Array.Resize(ref assigneeTodoArray, assigneeTodoArray.Length + 1);
		//			assigneeTodoArray[assigneeTodoArray.Length - 1] = TodoArray[i];
		//		}
		//	}
		//	return assigneeTodoArray;
		//}
		//public Todo[] FindByAssignee(Person assignee)
		//{
		//	Todo[] assigneeTodoArray = new Todo[0];

		//	for (int i = 0; i < Size(); i++)
		//	{
		//		if (TodoArray[i].Assignee == assignee)
		//		{
		//			Array.Resize(ref assigneeTodoArray, assigneeTodoArray.Length + 1);
		//			assigneeTodoArray[assigneeTodoArray.Length - 1] = TodoArray[i];
		//		}

		//	}
		//	return assigneeTodoArray;
		//}
		//public Todo[] FindUnassignedTodoItems()
		//{
		//	Todo[] unassignedTodoArray = new Todo[0];

		//	for (int i = 0; i < Size(); i++)
		//	{
		//		if (TodoArray[i].Assignee == null)
		//		{
		//			Array.Resize(ref unassignedTodoArray, unassignedTodoArray.Length + 1);
		//			unassignedTodoArray[unassignedTodoArray.Length - 1] = TodoArray[i];
		//		}

		//	}
		//	return unassignedTodoArray;
		//}

		//public void RemoveObjectFromTodoArray(int indexNumber)
		//{
		//	if (Size() > indexNumber)
		//	{
		//		if (Size() - 1 != indexNumber)//If Arrays last index is not the indexNumber, than replay the index value of the Index number 					//with last index value. 
		//		{
		//			TodoArray[indexNumber] = TodoArray[Size() - 1];
		//		}
		//		Array.Resize(ref TodoArray, Size() - 1);
		//	}
		//}


	}

}

