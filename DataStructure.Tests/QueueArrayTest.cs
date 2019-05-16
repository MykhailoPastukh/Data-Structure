using System;
using Xunit;

namespace DataStructure.Tests
{
    public class QueueArrayTest
    {
        [Fact]
        public void IsEmpty_EmptyQueueShouldReturnTrue()
        {
            // Arrange
            QueueArray sut = new QueueArray();
            bool expected = true;

            // Act
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Clear_ClearQueueArrayWithSomeNumbersShoulWork()
        {
            // Arrange
            QueueArray sut = new QueueArray();
            int expected = 0;

            // Act
            sut.Add(int.MaxValue);
            sut.Add(int.MinValue);
            sut.Add(42);
            sut.Clear();
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(10000)]
        public void Add_AddManyNumbersToQueueArrayShouldWork(int count)
        {
            // Arrange
            QueueArray sut = new QueueArray();
            int expected = count;
            
            // Act
            for (int i = 0; i < count; i++)
            {
                sut.Add(i);
            }
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100)]
        public void Get_GetNumbersFromQueueArrayShouldWork(int count)
        {
            // Arrange
            QueueArray sut = new QueueArray();

            // Act
            for (int i = 0; i < count; i++)
            {
                sut.Add(i);
            }

            // Assert
            for (int expected = 0; expected < count; expected++)
            {
                Assert.Equal(expected,sut.Get());
            }
        }

        [Fact]
        public void Get_GetFromEmptyQueueShouldNotWork()
        {
            // Arrange
            QueueArray sut = new QueueArray();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }
    }
}