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
            StackArray<int> sut = new StackArray<int>();
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
            StackArray<int> sut = new StackArray<int>();
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
            StackArray<int> sut = new StackArray<int>();

            // Act 

            // Assert
            Assert.Throws<DataStructureIsEmptyOnReadExeption>(() => sut.Get());
        }

        [Fact]
        public void Clear_ClearStackWithSomeElementsShouldWork()
        {
            // Arrange
            StackArray<int> sut = new StackArray<int>();
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
            StackArray<int> sut = new StackArray<int>();
            bool expected = true;

            // Act            
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange 
            StackArray<double> sut = new StackArray<double>();
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
            StackArray<double> sut = new StackArray<double>();
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
            StackArray<double> sut = new StackArray<double>();
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }
    }
}