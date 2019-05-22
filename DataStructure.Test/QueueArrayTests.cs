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
            QueueArray<int> sut = new QueueArray<int>();
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
            QueueArray<int> sut = new QueueArray<int>();
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
            QueueArray<int> sut = new QueueArray<int>();
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
            QueueArray<int> sut = new QueueArray<int>();

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
            QueueArray<int> sut = new QueueArray<int>();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange 
            QueueArray<double> sut = new QueueArray<double>();
            double expected = 42.2;

            // Act
            for (int i = 0; i < 10; i++)
            {
                sut.Add(i);
            }
            sut[5] = 42.2;
            double actual = sut[5];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_GetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            QueueArray<double> sut = new QueueArray<double>();
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5]);
        }

        [Fact]
        public void Indexer_SetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            QueueArray<double> sut = new QueueArray<double>();
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }
    }
}