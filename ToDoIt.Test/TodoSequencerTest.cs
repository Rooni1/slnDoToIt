using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Test
{
    public class TodoSequencerTests
    {
        [Fact]
        public void ReturnZeroAtTheStart()
        {
            //Arrange          
            int exptected = 0;

            //Act
            int actual = TodoSequencer.TodoId;

            //Assert
            Assert.Equal(exptected, actual);
        }

        [Fact]
        public void ReturnThreeAfterThreeCalls()
        {
            //Arrange
            TodoSequencer.ResetTodo();
            int expected = 3;
            for (int i = 0; i < 2; i++)
            {
                TodoSequencer.NextTodoId();
            }
            //Act 
            int actual = TodoSequencer.NextTodoId();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ResettodoIdToZero()
        {
            //Arrange
            TodoSequencer.ResetTodo();
            int expectedBeforeReset = 3;
            int expectedAfterReset = 0;
            for (int i = 0; i < 2; i++)
            {
                TodoSequencer.NextTodoId();
            }
            //Act
            int actualBeforeReset = TodoSequencer.NextTodoId();
            TodoSequencer.ResetTodo();
            int actualAfterReset = TodoSequencer.TodoId;

            //Assert
            Assert.Equal(expectedBeforeReset, actualBeforeReset);
            Assert.Equal(expectedAfterReset, actualAfterReset);

        }
    }
}
