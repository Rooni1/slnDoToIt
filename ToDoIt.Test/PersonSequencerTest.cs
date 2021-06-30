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
            int expectedPersonId1 = 1;

            // Act

            int actualPersonId = PersonSequencer.nextPersonId();
            int actualPersonId1 = PersonSequencer.nextPersonId();

            // Assert
            Assert.NotEqual(expectedPersonId, actualPersonId);
            Assert.NotEqual(expectedPersonId1, actualPersonId1);

            PersonSequencer.Reset();
        }
       
    }
}
