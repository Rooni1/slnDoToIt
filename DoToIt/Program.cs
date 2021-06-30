using System;
using System.Collections.Generic;
using ToDoIt.Model;



namespace ToDoIt
{
    class Program
    {
        static void Main(string[] args)
        {
           Todo testTodo = new Todo("desc", 1);

            Console.WriteLine(testTodo.ToString());

            Console.ReadLine();
           
        }
    }

   

}
