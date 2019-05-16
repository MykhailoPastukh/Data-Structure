using System;
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
            StackArray sut = new StackArray();
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
        [InlineData(1000)]
        [InlineData(10000)]
        public void Get_SetAndGetNumberShouldBeTheSame(int count)
        {
            // Arrange
            StackArray sut = new StackArray();
            int expected = 17;

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
        public void Get_GetFromEmptyStack()
        {
            // Arrange
            StackArray sut = new StackArray();

            // Act 

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }

        [Fact]
        public void Clear_ClearStackWithSomeElementsShouldWork()
        {
            // Arrange
            StackArray sut = new StackArray();
            int expected = 0;

            // Act
            sut.Add(42);
            sut.Add(17);
            sut.Add(int.MaxValue);
            sut.Clear();
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyStackArrayShouldReturnTrue()
        {
            // Arrange
            StackArray sut = new StackArray();
            bool expected = true;

            // Act            
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
