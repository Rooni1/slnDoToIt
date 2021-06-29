using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Test
{
    public class PersonSequencerTest
    {

        [Fact]
        public void PersonId()
        {
            // Arrange
            int expectedPersonId = 0;

            // Act
            
            int actualPersonId = PersonSequencer.nextPersonId();

            // Assert
            Assert.NotEqual(expectedPersonId, actualPersonId);
        }
    }
}
