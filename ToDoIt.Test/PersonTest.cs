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
        [Fact]

        public void PersonFirstNameNotNull()
        {
            //Arrange
            string expectedFirstName = null;
            string expectedLastName = "Usman";
            int expectedPersonId = 1;
           

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new Person(expectedFirstName, expectedLastName, expectedPersonId));

            //Assert

            Assert.Equal("First name can't be empty/null Please Fill the first name", caughtDrinkException.Message);

        }
        [Fact]
        public void PersonFirstNameNotEmpty()
        {
            //Arrange
            string expectedFirstName = "";
            string expectedLastName = "Usman";
            int expectedPersonId = 1;

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                      new Person(expectedFirstName, expectedLastName, expectedPersonId));

            //Assert

            Assert.Equal("First name can't be empty/null Please Fill the first name", caughtDrinkException.Message);

        }
        [Fact]
        public void PersonLastNameNotNull()
        {
            //Arrange
            string expectedFirstName = "Ali";
            string expectedLastName = null;
            int expectedPersonId = 1;


            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                       new Person(expectedFirstName, expectedLastName, expectedPersonId));

            //Assert

            Assert.Equal("Last name can't be empty/null Please Fill the last name", caughtDrinkException.Message);

        }
        [Fact]
        public void PersonLastNameNotEmpty()
        {
            //Arrange
            string expectedFirstName = "Ali";
            string expectedLastName = "";
            int expectedPersonId = 1;

            //Act

            var caughtDrinkException = Assert.Throws<ArgumentException>(() =>
                                      new Person(expectedFirstName, expectedLastName, expectedPersonId));

            //Assert

            Assert.Equal("Last name can't be empty/null Please Fill the last name", caughtDrinkException.Message);

        }



    }
}
