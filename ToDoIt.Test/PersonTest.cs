using System;
using ToDoIt.Model;
using Xunit;




namespace ToDoIt.Test
{
    public class PersonTest
    {
        [Fact]
        public void AddPersons()
        {
            // Arrange
            string firstName = "Ali";
            string lastName = "Usman";

            // Act

            Person TestPerson = new Person(firstName, lastName);

            // Assert
            Assert.Contains(firstName,TestPerson.FirstName);
            Assert.Contains(lastName, TestPerson.LastName);
            

        }
    }
}
