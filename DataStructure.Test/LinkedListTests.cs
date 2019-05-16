using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructure.Test
{
    public class LinkedListTests
    {
        [Fact]
        public void Size_EmptyLinkedListShouldReturnZero()
        {
            // Arrange
            int expected = 0;

            // Act
            LinkedList sut = new LinkedList();
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyLinkedListShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            // Act
            LinkedList sut = new LinkedList();
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
            int expected = count;

            // Act
            LinkedList sut = new LinkedList();
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
            Assert.Throws<NullReferenceException>(() => sut.Get());
        }

        [Fact]
        public void Get_GetFirstFromEmptyLinkedListShouldNotWork()
        {
            // Arrange
            LinkedList sut = new LinkedList();

            // Act

            // Assert
            Assert.Throws<NullReferenceException>(() => sut.GetFirst());
        }
    }
}
