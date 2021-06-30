using System;
using ToDoIt.Model;
using Xunit;
using ToDoIt.Data;




namespace ToDoIt.Test
{
    public class PersonTest
    {
        [Fact]
        public void AddPersons()
        {
            // Arrange
            string expectedFirstName = "Ali";
            string expectedLastName = "Usman";
            int expectedPersonId = 1;
            Person TestPerson = new Person(expectedFirstName, expectedLastName, expectedPersonId);

            // Act
            string actualFirstName = TestPerson.FirstName;
            string actualLastName = TestPerson.LastName;
            int actualPersonId = TestPerson.PersonId;


            // Assert
            
            Assert.Equal(expectedFirstName, actualFirstName);
            Assert.Equal(expectedLastName, actualLastName);
            Assert.Equal(expectedPersonId, actualPersonId);
            PersonSequencer.Reset();


        }
        [Fact]
        public void PersonIdWorks()
        {
            //Arrange
            int expectedPersonId = 1;
            string expectedFirstName  = "Mossa";
            string expectedLastName   = "Ali";
            int expectedPersonId1 = 2;
            string expectedFirstName1 = "Umaima";
            string expectedLastName1  = "Munir";

            //Act
            Person TestPerson1 = new Person(expectedFirstName, expectedLastName, expectedPersonId);
            Person TestPerson2 = new Person(expectedFirstName1, expectedLastName1, expectedPersonId1);

            //Assert
            Assert.NotEqual(TestPerson1.PersonId, TestPerson2.PersonId);

            //TestPerson1.PersonId= PersonSequencer.Reset();
        }
        
        
        
    }
}
