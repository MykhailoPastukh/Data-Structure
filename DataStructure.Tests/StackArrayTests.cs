using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataStructure.Tests
{
    public class StackArrayTests
    {
        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        public void Add_AddNumbersToStackArrayShouldWork(int count)
        {
            // Arrange
            int expected = count;

            // Act
            StackArray sut = new StackArray();
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
        [InlineData(1000)]
        [InlineData(10000)]
        public void Get_SetAndGetNumberShouldBeTheSame(int count)
        {
            // Arrange
            int expected = 17;

            // Act
            StackArray sut = new StackArray();
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
        public void Get_GetFromEmptyStack()
        {
            // Arrange

            // Act 
            StackArray sut = new StackArray();

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }

        [Fact]
        public void Clear_ClearStackWithSomeElementsShouldWork()
        {
            // Arrange
            StackArray expected = new StackArray();

            // Act
            StackArray actual = expected;
            actual.Add(42);
            actual.Add(17);
            actual.Add(int.MaxValue);
            actual.Clear();

            // Assert
            Assert.Same(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyStackArrayShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            // Act
            StackArray sut = new StackArray();
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
