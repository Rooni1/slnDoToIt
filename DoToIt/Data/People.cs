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
            Person foundPerson = null;
            for (int searchIndex = 0; searchIndex < personArray.Length; searchIndex++)
            {
                if (personArray[searchIndex].PersonId == personId)
                {
                    foundPerson = personArray[searchIndex];
                    break;
                }
             
            }
            return foundPerson;
        }
        public Person AddPerson(string firstName,string lastName)
        {
           
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

        public Person[] RemovePersonFromPeopleArray(Person personToRemove)
        {
            int personIndexNumber = -1;

            for (int i = 0; i < personArray.Length; i++)
            {

                if(personArray[i] == personToRemove)
                {
                    personIndexNumber = i;
                    break;
                }
            }
            if (personArray.Contains(personToRemove))
            {
                if (Size() - 1 != personIndexNumber)//If Arrays last index is not the indexNumber, than replay the index value of the Index number //with last index value. 
                {
                    personArray[personIndexNumber] = personArray[Size() - 1];
                }
                Array.Resize(ref personArray, Size() - 1);
            }
            return personArray;
        }
        public void  Test()
        {

        }
    }
}
