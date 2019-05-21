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
            StackLinkedList sut = new StackLinkedList();
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
            StackLinkedList sut = new StackLinkedList();
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
            StackLinkedList sut = new StackLinkedList();
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
            StackLinkedList sut = new StackLinkedList();
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
            StackLinkedList sut = new StackLinkedList();
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
            StackLinkedList sut = new StackLinkedList();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }
    }
}