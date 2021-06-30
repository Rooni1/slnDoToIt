using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Model;
using System.Linq;

namespace ToDoIt.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0];
        public int Size()
        {
            return personArray.Length; 
                        
        }
        public Person[] FindAll()
        {
            return personArray;
        }
        public Person FindById(int personId)
        {
            
            return personArray[personId];
        }
        public Person AddPerson(string firstName,string lastName)
        {
            //personId = PersonSequencer.nextPersonId(); // Assign uniq Id to person.
            Person addPerson = new Person(firstName, lastName, PersonSequencer.nextPersonId());
            // Get size of Array.
            int sizeOfPersonArray = Size();
            // incrementing the size of array.
            ++sizeOfPersonArray;
            // Increase the size of Array when add new person object
            Array.Resize(ref personArray, sizeOfPersonArray);
            // Adding person object to Array.

            int currentIndex = personArray.Length - 1;
            personArray[currentIndex] = addPerson;
            return addPerson;
        }
        public void Clear()
        {
            Array.Clear(personArray,0,personArray.Length);
        }
    }
}
