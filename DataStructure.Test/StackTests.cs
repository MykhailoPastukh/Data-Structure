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
            Stack sut = new Stack();
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
            Stack sut = new Stack();
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
            Stack sut = new Stack();
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
            Stack sut = new Stack();
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
            Stack sut = new Stack();
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