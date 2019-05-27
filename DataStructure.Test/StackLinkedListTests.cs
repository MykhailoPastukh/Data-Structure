using System;
using Xunit;

namespace DataStructure.Tests
{
    public class StackLinkedListTests
    {
        [Fact]
        public void Size_EmptyStackShouldReturnZero()
        {
            // Arrange
            StackLinkedList<int> sut = new StackLinkedList<int>();
            int expected = 0;

            // Act
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyStackShouldReturnTrue()
        {
            // Arrange
            StackLinkedList<int> sut = new StackLinkedList<int>();
            bool expected = true;

            // Act
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void Add_AddNumbersToStackShouldWork(int count)
        {
            // Arrange
            StackLinkedList<int> sut = new StackLinkedList<int>();
            int expected = count;

            // Act
            for (int i = 0; i < count; i++)
            {
                sut.Add(i);
            }
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void Get_SetAndGetNumberShouldBeTheSame(int count)
        {
            // Arrange
            StackLinkedList<int> sut = new StackLinkedList<int>();
            int expected = 42;

            // Act
            sut.Add(expected);
            for (int i = 0; i < count; i++)
            {
                sut.Add(i);
            }
            for (int i = 0; i < count; i++)
            {
                sut.Get();
            }
            int actual = sut.Get();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Clear_ClearStackWithTwoNumbersShouldWork()
        {
            // Arrange
            StackLinkedList<int> sut = new StackLinkedList<int>();
            bool expected = true;

            // Act
            sut.Add(int.MaxValue);
            sut.Add(int.MinValue);
            sut.Clear();
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_GetFromEmptyStackShouldThrowExeption()
        {
            // Arrange
            StackLinkedList<int> sut = new StackLinkedList<int>();

            // Act

            // Assert
            Assert.Throws<DataStructureIsEmptyOnReadExeption>(() => sut.Get());
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange
            StackLinkedList<int> sut = new StackLinkedList<int>();
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
        public void Indexer_GetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            StackLinkedList<double> sut = new StackLinkedList<double>();
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
            StackLinkedList<double> sut = new StackLinkedList<double>();
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }
    }
}