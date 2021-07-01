using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;
using System.Linq;

namespace ToDoIt.Test
{
    public class PeopleTest
    {
        [Fact]
        public void AddPersons()
        {
            // Arrange
            string expectedFirstName = "Ali";
            string expectedLastName = "Usman";
           // int expectedPersonId = 1;
           
            string expectedFirstName1 = "Mossa";
            string expectedLastName1 = "Ali";
            //int expectedPersonId1 = 2; 
           

            // Act
                 
            People actualPeople = new People();
            Person actualPerson = actualPeople.AddPerson(expectedFirstName, expectedLastName);
            Person actualPerson1 = actualPeople.AddPerson(expectedFirstName1, expectedLastName1);
            Person[] testPersonArray = actualPeople.FindAll();

            // Assert
            Assert.Equal(expectedFirstName, actualPerson.FirstName);
            Assert.Equal(expectedLastName, actualPerson.LastName);
            
            Assert.Equal(expectedFirstName1, actualPerson1.FirstName);
            Assert.Equal(expectedLastName1, actualPerson1.LastName);
            Assert.Contains(actualPerson, testPersonArray);
            Assert.Contains(actualPerson1, testPersonArray);
            Assert.NotEqual(actualPerson.PersonId, actualPerson1.PersonId);
        }

        [Fact]
        public void RemovePerson()
        {
            // Arrange
            string expectedFirstName = "Ali";
            string expectedLastName = "Usman";

            string expectedFirstName1 = "Mossa";
            string expectedLastName1 = "Ali";
          

            string expectedFirstName2 = "Laura";
            string expectedLastName2 = "Alison";

            // Act

            People actualPeople = new People();
            Person actualPerson = actualPeople.AddPerson(expectedFirstName, expectedLastName);
            Person actualPerson1 = actualPeople.AddPerson(expectedFirstName1, expectedLastName1);
            Person actualPerson2 = actualPeople.AddPerson(expectedFirstName2, expectedLastName2);
            Person[] testPersonArray = actualPeople.FindAll();

            //Act
            Person[] actualArray = actualPeople.RemovePersonFromPeopleArray(actualPerson);

            //Assert
            Assert.Equal(testPersonArray[0], actualArray[0]);
            Assert.NotEqual(testPersonArray.Length, actualArray.Length);


        }
       

    }
}
