using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using Xunit;

namespace DataStructure.Tests
{
    public class StackTests
    {
        [Fact]
        public void Size_EmptyStackShouldReturnZero()
        {
            // Arrange
            int expected = 0;

            // Act
            Stack sut = new Stack();
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyStackShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            // Act
            Stack sut = new Stack();
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
            int expected = count;

            // Act
            Stack sut = new Stack();
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
            int expected = 42;

            // Act
            Stack sut = new Stack();
            sut.Add(expected);
            for (int i = 0; i < count; i++)
            {
                sut.Add(42);
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
            bool expected = true;

            // Act
            Stack sut = new Stack();
            sut.Add(int.MaxValue);
            sut.Add(int.MinValue);
            sut.Clear();
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_GetFromEmptyStackShouldNotWork()
        {
            // Arrange
            Stack sut = new Stack();

            // Act

            // Assert
            Assert.Throws<NullReferenceException>(() => sut.Get());
        }
    }
}