using System;
using Xunit;

namespace DataStructure.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void Size_EmptyLinkedListShouldReturnZero()
        {
            // Arrange
            LinkedList sut = new LinkedList();
            int expected = 0;

            // Act
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyLinkedListShouldReturnTrue()
        {
            // Arrange
            LinkedList sut = new LinkedList();
            bool expected = true;

            // Act
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(1000000)]
        public void Add_AddNumbersToLinkedListShouldWork(int count)
        {
            // Arrange
            LinkedList sut = new LinkedList();
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
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(1000000)]
        public void Get_SetAndGetNumberShouldBeTheSame(int count)
        {
            // Arrange
            LinkedList sut = new LinkedList();
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
        public void GetFirst_GetNumbersShouldWork()
        {
            // Arrange
            LinkedList sut = new LinkedList();
            int expected = 99;

            // Act
            for (int i = 0; i < 100; i++)
            {
                sut.Add(i);
            }
            for (int i = 0; i < 99; i++)
            {
                sut.GetFirst();
            }
            int actual = sut.GetFirst();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Clear_ClearLinkedListWithTwoNumbersShouldWork()
        {
            // Arrange
            LinkedList sut = new LinkedList();
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
        public void Get_GetFromEmptyLinkedListShouldNotWork()
        {
            // Arrange
            LinkedList sut = new LinkedList();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }

        [Fact]
        public void Get_GetFirstFromEmptyLinkedListShouldNotWork()
        {
            // Arrange
            LinkedList sut = new LinkedList();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.GetFirst());
        }
    }
}