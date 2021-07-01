using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;
using System.Linq;

namespace ToDoIt.Test
{
    public class TodoItemsTests
    {
        [Fact]
        public void ReturnZeroAtTheStart()
        {
            //Arrange
            
            int exptected = 0;
            TodoItems sut = new TodoItems();
            sut.Clear();
            TodoSequencer.ResetTodo();

            //Act
            int actual = sut.Size();

            //Assert
            Assert.Equal(exptected, actual);
        }

        [Fact]
        public void ReturnThreeAfterAddingTreeItems()
        {
            //Arrange
            int expected = 3;
            TodoItems sut = new TodoItems();
            sut.Clear();
            TodoSequencer.ResetTodo();
            string item1 = "Food Shipment";
            string item2 = "Electronic Shipment";
            string item3 = "Pharmasutical Shipment";
            sut.AddItemToTodoArray(item1);
            sut.AddItemToTodoArray(item2);
            sut.AddItemToTodoArray(item3);

            //Act 
            int actual = sut.Size();

            //Assert
            Assert.Equal(expected, actual);
            sut.Clear();
        }

        [Fact]
        public void ReturnSizeZeroAfterClear()
        {
            //Arrange
            int expected = 0;
            TodoItems sut = new TodoItems();
            TodoSequencer.ResetTodo();
            string item1 = "Food Shipment";
            string item2 = "Electronic Shipment";
            string item3 = "Pharmasutical Shipment";
            sut.AddItemToTodoArray(item1);
            sut.AddItemToTodoArray(item2);
            sut.AddItemToTodoArray(item3);

            //Act 
            sut.Clear();
            int actual = sut.Size();

            //Assert
            Assert.Equal(expected, actual);
            sut.Clear();
        }

        [Fact]
        public void ReturnSecondItemDescription()
        {
            //Arrange          
            string expected = "Electronic Shipment";
            TodoItems sut = new TodoItems();
            sut.Clear();
            TodoSequencer.ResetTodo();

            string item1 = "Food Shipment";
            string item2 = "Electronic Shipment";
            string item3 = "Pharmasutical Shipment";

            sut.AddItemToTodoArray(item1);
            sut.AddItemToTodoArray(item2);
            sut.AddItemToTodoArray(item3);

            Todo newItem = sut.FindById(2);

            //Act
            string actual = newItem.Description;

            //Assert
            Assert.Equal(expected, actual);
            

        }
        [Fact]
        public void ReturnTodoNullIfIdDoesNotExist()
        {
            //Arrange
            
            TodoItems sut = new TodoItems();
            sut.Clear();
            TodoSequencer.ResetTodo();
            Todo expected = null;

            string item1 = "Food Shipment";
            string item2 = "Electronic Shipment";
            string item3 = "Pharmasutical Shipment";

            sut.AddItemToTodoArray(item1);
            sut.AddItemToTodoArray(item2);
            sut.AddItemToTodoArray(item3);

            //Act
            Todo actual = sut.FindById(4);

            //Assert
            Assert.Equal(expected, actual);
            
        }

        [Fact]
        public void ArrayShouldBeSame()
        {

            //Arrange

            string Desc1 = "Video Games";
            string Desc2 = "Car parts";
            string Desc3 = "Smart watches";
            string Desc4 = "Routers";
            int id1 = 1;
            int id2 = 2;
            int id3 = 3;
            int id4 = 4;

            TodoItems sut = new TodoItems();
            sut.Clear();
            TodoSequencer.ResetTodo();
            Todo[] expected = new Todo[] {
            
                new Todo(Desc1, id1),
                new Todo(Desc2, id2),
                new Todo(Desc3, id3),
                new Todo(Desc4, id4),
            
            };

            sut.AddItemToTodoArray(Desc1);
            sut.AddItemToTodoArray(Desc2);
            sut.AddItemToTodoArray(Desc3);
            sut.AddItemToTodoArray(Desc4);

            //Act
            Todo[] actual = sut.FindAll();

            //Assert
            Assert.Equal(expected[0].Description, actual[0].Description);
            Assert.Equal(expected[0].ToDoId, actual[0].ToDoId);
            Assert.Equal(expected[2].Done, actual[2].Done);
            Assert.Equal(expected.Length, actual.Length);

        }
        [Fact]
        public void IdsAreNotTheSame()
        {
            //Arrange
            string Desc1 = "Video Games";
            string Desc2 = "Car parts";

            TodoItems sut = new TodoItems();
            sut.Clear();
            TodoSequencer.ResetTodo();

            //Act
            sut.AddItemToTodoArray(Desc2);
            sut.AddItemToTodoArray(Desc1);
            Todo[] testArray = sut.FindAll();


            //Assert
            Assert.NotEqual(testArray[0].ToDoId, testArray[1].ToDoId);
            

        }

        [Fact]
        public void CheckForStatus()
        {
            //Arrange
            TodoItems sut = new TodoItems();
            sut.Clear();
            TodoSequencer.ResetTodo();

            bool notDone = false;
            bool done = true;
   
            string desc1 = "Fish";
            string desc2 = "Veggies";
            string desc3 = "Beans";
            string desc4 = "Meat";
            string desc5 = "Cigg";

            int expectedArrayLength1 = 2;
            int expectedArrayLength2 = 3;

            sut.AddItemToTodoArray(desc1);
            sut.AddItemToTodoArray(desc2);
            sut.AddItemToTodoArray(desc3);
            sut.AddItemToTodoArray(desc4);
            sut.AddItemToTodoArray(desc5);

            Todo[] testArray = sut.FindAll();
            testArray[0].TodoStatus(notDone);
            testArray[1].TodoStatus(done);
            testArray[2].TodoStatus(done);
            testArray[3].TodoStatus(done);
            testArray[4].TodoStatus(notDone);
           
            //Act
            Todo[] actualStatus = sut.FindByDoneStatus(notDone);
            Todo[] actualStatus2 = sut.FindByDoneStatus(done);


            //Assert
            Assert.Equal(expectedArrayLength1, actualStatus.Length);
            Assert.Equal(expectedArrayLength2, actualStatus2.Length);
            Assert.Equal(desc1, actualStatus[0].Description);
            Assert.Equal(desc4, actualStatus2[2].Description);

          //  Assert.Equal(todo1, actualStatus.Contains(todo1));

       
        }

        [Fact]
        public void CheckForId()
        {

            //Arrange
            string expectedFirstName = "Haroon";
            string expectedLastName = "Munir";

            int expectedId = 1;

            Person newWorker = new Person(expectedFirstName, expectedLastName, expectedId);

            TodoItems sut = new TodoItems();
            sut.Clear();
            PersonSequencer.Reset();
            TodoSequencer.ResetTodo();

            string desc1 = "Fish";
            string desc2 = "Veggies";
            string desc3 = "Beans";
            string desc4 = "Meat";
            string desc5 = "Cigg";

            sut.AddItemToTodoArray(desc1);
            sut.AddItemToTodoArray(desc2);
            sut.AddItemToTodoArray(desc3);
            sut.AddItemToTodoArray(desc4);
            sut.AddItemToTodoArray(desc5);

            Todo[] testArray = sut.FindAll();
          
            testArray[0].AssignPerson(newWorker);
            testArray[3].AssignPerson(newWorker);
            

            //Act
            Todo[] actual = sut.FindByAssignee(PersonSequencer.nextPersonId());

            //Assert
            Assert.Equal(expectedId, actual[0].Assignee.PersonId);
            

        }
        [Fact]
        public void FindByPerson()
        {

            //Arrange
            bool notDone = false;
            bool done = true;
            string expectedFirstName = "Billy";
            string expectedLastName = "Rosehag";
            int expectedId = 1;

            string expectedFirstName1 = "Haroon";
            string expectedLastName1 = "Munir";
            int expectedId1 = 2;

            Person workAssignee = new Person(expectedFirstName, expectedLastName, expectedId);
            Person workAssignee1 = new Person(expectedFirstName1, expectedLastName1, expectedId1);

            TodoItems sut = new TodoItems();
            sut.Clear();
            PersonSequencer.Reset();
            TodoSequencer.ResetTodo();

            string desc1 = "Fish";
            string desc2 = "Veggies";
            string desc3 = "Beans";
            string desc4 = "Meat";
            string desc5 = "Cigg";

            sut.AddItemToTodoArray(desc1);
            sut.AddItemToTodoArray(desc2);
            sut.AddItemToTodoArray(desc3);
            sut.AddItemToTodoArray(desc4);
            sut.AddItemToTodoArray(desc5);

            Todo[] testArray = sut.FindAll();

            testArray[0].AssignPerson(workAssignee);
            testArray[3].AssignPerson(workAssignee1);
            testArray[0].TodoStatus(done);
            testArray[3].TodoStatus(notDone);

            //Act
            Todo[] actual = sut.FindByAssignee(workAssignee);
            Todo[] actual1 = sut.FindByAssignee(workAssignee1);


            //Assert
            Assert.Equal(expectedFirstName, actual[0].Assignee.FirstName);
            Assert.Equal(expectedLastName, actual[0].Assignee.LastName);
            Assert.Equal(expectedId, actual[0].Assignee.PersonId);

            Assert.Equal(expectedFirstName1, actual1[0].Assignee.FirstName);
            Assert.Equal(expectedLastName1, actual1[0].Assignee.LastName);
            Assert.NotEqual(actual[0].Assignee.PersonId,actual1[0].Assignee.PersonId);

        }
        [Fact]
        public void FindUnassignedTodoItems()
        {

            //Arrange
           
            string expectedFirstName = "Billy";
            string expectedLastName = "Rosehag";
            int expectedId = 1;

            string expectedFirstName1 = "Haroon";
            string expectedLastName1 = "Munir";
            int expectedId1 = 2;

            Person workAssignee = new Person(expectedFirstName, expectedLastName, expectedId);
            Person workAssignee1 = new Person(expectedFirstName1, expectedLastName1, expectedId1);

            TodoItems sut = new TodoItems();
            sut.Clear();
            PersonSequencer.Reset();
            TodoSequencer.ResetTodo();

            string desc1 = "Fish";
            string desc2 = "Veggies";
            string desc3 = "Beans";
            string desc4 = "Meat";
            string desc5 = "Cigg";

            sut.AddItemToTodoArray(desc1);
            sut.AddItemToTodoArray(desc2);
            sut.AddItemToTodoArray(desc3);
            sut.AddItemToTodoArray(desc4);
            sut.AddItemToTodoArray(desc5);

            Todo[] testArray = sut.FindAll();

            testArray[0].AssignPerson(workAssignee);
            testArray[3].AssignPerson(workAssignee1);
           

            //Act
            Todo[] actual = sut.FindUnassignedTodoItems();
            Todo[] actual1 = sut.FindUnassignedTodoItems();


            //Assert

            Assert.Null(actual[0].Assignee);
            Assert.NotEqual(testArray.Length,actual.Length);
            Assert.NotEqual(testArray.Length, actual1.Length);
            

            

        }

    }
}

