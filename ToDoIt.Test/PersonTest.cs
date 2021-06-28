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
            string expectedFirstName = "Ali";
            string expectedLastName = "Usman";
            Person TestPerson = new Person(expectedFirstName, expectedLastName);

            // Act
            string actualFirstName = TestPerson.FirstName;
            string actualLastName = TestPerson.LastName;


            // Assert
            //Assert.Contains(expectedFirstName, actualFirstName);
            //Assert.Contains(expectedLastName, actualLastName);
            Assert.Equal(expectedFirstName, actualFirstName);
            Assert.Equal(expectedLastName, actualLastName);


        }
        [Fact]
        public void PersonIdWorks()
        {
            //Arrange
            string expectedFirstName  = "Mossa";
            string expectedLastName   = "Ali";
            string expectedFirstName1 = "Umaima";
            string expectedLastName1  = "Munir";

            //Act
            Person Testperson1 = new Person(expectedFirstName, expectedLastName);
            Person Testperson2 = new Person(expectedFirstName1, expectedLastName1);

            //Assert
            Assert.NotEqual(Testperson1.id, Testperson2.id);

        }
    }
}
