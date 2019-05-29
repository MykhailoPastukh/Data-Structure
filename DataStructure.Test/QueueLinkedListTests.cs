using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructure.Tests
{
    public class QueueLinkedListTests
    {
        [Fact]
        public void Filter_FilterShouldWork()
        {
            // Arrange
            QueueLinkedList<double> sut = new QueueLinkedList<double> { double.MaxValue, 2.7, 4.25, 5.28, 1.3, 2.8 };
            double[] expected = { 5.28, 4.25, double.MaxValue };

            // Act
            IEnumerable<double> actual = sut.Filter(item => item > 4.1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyQueueShouldReturnTrue()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
            bool expected = true;

            // Act
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Clear_ClearQueueWithSomeNumbersShoulWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
            int expected = 0;

            // Act
            sut.Add(int.MaxValue);
            sut.Add(int.MinValue);
            sut.Add(42);
            sut.Clear();
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(100000)]
        public void Add_AddManyNumbersToQueueShouldWork(int count)
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
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

        [Fact]
        public void Get_GetNumbersFromQueueShouldWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                sut.Add(i);
            }

            // Assert
            for (int expected = 0; expected < 100; expected++)
            {
                Assert.Equal(expected, sut.Get());
            }
        }

        [Fact]
        public void Get_GetFromEmptyQueueShouldThrowExeption()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();

            // Act

            // Assert
            Assert.Throws<DataStructureIsEmptyOnReadExeption>(() => sut.Get());
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
            int expected = 42;

            // Act
            for (int i = 0; i < 10; i++)
            {
                sut.Add(i);
            }
            sut[5] = 42;
            int actual = sut[5];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_IndexerGetAndSetFromEndShouldWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
            int expected = 42;

            // Act
            for (int i = 0; i < 10; i++)
            {
                sut.Add(i);
            }
            sut[9] = 42;
            int actual = sut[9];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_GetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            QueueLinkedList<double> sut = new QueueLinkedList<double>();
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
            QueueLinkedList<double> sut = new QueueLinkedList<double>();
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }

        [Fact]
        public void Enumerable_EnumShouldWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int> { 5, 4, 3, 2, 1 };
            int[] arr = new int[5];

            // Act
            int i = 0;
            foreach (var item in sut)
            {
                arr[i] = item;
                i++;
            }

            // Assert

            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, arr);
        }
    }
}