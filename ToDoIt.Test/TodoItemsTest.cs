using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;

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

    }
}

