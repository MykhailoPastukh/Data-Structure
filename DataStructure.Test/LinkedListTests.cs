using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructure.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void Filter_FilterShouldWork()
        {
            // Arrange
            LinkedList<int> sut = new LinkedList<int> { 1, 3, 4, 5, 7, 8 };
            int[] expected = new int[] { 5, 7, 8 };

            // Act
            IEnumerable<int> actual = sut.Filter(item => item > 4);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Enumerable_EnumShouldWork()
        {
            // Arrange
            LinkedList<int> sut = new LinkedList<int> { 1, 2, 3, 4, 5 };
            int[] arr = new int[5];

            // Act
            int i = 0;
            sut.GetEnumerator();
            foreach (var item in sut)
            {
                arr[i] = item;
                i++;
            }

            // Assert

            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, arr);
        }
        [Fact]
        public void Size_EmptyLinkedListShouldReturnZero()
        {
            // Arrange
            LinkedList<int> sut = new LinkedList<int>();
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
            LinkedList<int> sut = new LinkedList<int>();
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
            LinkedList<int> sut = new LinkedList<int>();
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
            LinkedList<int> sut = new LinkedList<int>();
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
            LinkedList<int> sut = new LinkedList<int>();
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
            LinkedList<int> sut = new LinkedList<int>();
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
            LinkedList<int> sut = new LinkedList<int>();

            // Act

            // Assert
            Assert.Throws<DataStructureIsEmptyOnReadExeption>(() => sut.Get());
        }

        [Fact]
        public void Get_GetFirstFromEmptyLinkedListShouldNotWork()
        {
            // Arrange
            LinkedList<int> sut = new LinkedList<int>();

            // Act

            // Assert
            Assert.Throws<DataStructureIsEmptyOnReadExeption>(() => sut.GetFirst());
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange 
            LinkedList<double> sut = new LinkedList<double>();
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
        public void Indexer_IndexerGetAndSetFromEndShouldWork()
        {
            // Arrange 
            LinkedList<double> sut = new LinkedList<double>();
            double expected = 42.2;

            // Act
            for (int i = 0; i < 10; i++)
            {
                sut.Add(i);
            }
            sut[9] = 42.2;
            double actual = sut[9];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_GetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            LinkedList<double> sut = new LinkedList<double>
            {
                1,
                2
            };

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(()=>sut[5]);
        }

        [Fact]
        public void Indexer_SetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            LinkedList<double> sut = new LinkedList<double>();

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[0] = 10);
        }
    }
}