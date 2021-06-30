using System;
using ToDoIt.Model;
using Xunit;




namespace ToDoIt.Test
{
    public class TodoTest
    {
       
        [Fact]
        public void ReturnTodoInfo()
        {
            //Arrange

            string expectedDesc = "Food shipment";
            int exptectedId = 1;
            Todo sut = new Todo(expectedDesc, exptectedId);

            //Act
            string actualDesc = sut.Description;
            int actualId = sut.ToDoId;

            //Assert
            Assert.Equal(expectedDesc, actualDesc);
            Assert.Equal(exptectedId, actualId);
        }

        [Fact]
        public void GiveExceptionIfNullorWhiteSpaces()
        {

            string expected = null;

            Todo sut = new Todo(" ", 0);

            Assert.Equal(expected, sut.Description);


        }

        [Fact]
        public void DoneWillReturnFalseAtStart()
        {
            //Arrange
            Todo sut = new Todo("Will give False", 0);

            //Assert
            Assert.False(sut.Done);
        }

        [Fact]
        public void AssigneeIsNullIfNotAssigned()
        {
            //Arrange
            Todo sut = new Todo("desc", 0);

            //Assert
            Assert.Null(sut.Assignee);
        }

        [Fact]
        public void AssigneeGetAssigned()
        {
            //Arrange
            string firstName = "Jane";
            string lastName = "Doe";
            int id = 1;
            Todo sut = new Todo("Desc", 0);
            Person expected = new Person(firstName, lastName, id);

            //Act
            sut.AssignPerson(expected);

            //Assert
            Assert.Equal(expected, sut.Assignee);
        }
    }
}
