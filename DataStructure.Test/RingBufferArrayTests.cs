using System;
using Xunit;

namespace DataStructure.Tests
{
    public class RingBufferArrayTests
    {
        [Fact]
        public void IsEmpty_EmptyRingBufferShouldReturnTrue()
        {
            // Arrange
            RingBufferArray<int> sut = new RingBufferArray<int>(5);
            bool expected = true;

            // Act
            sut.Add(42);
            sut.Get();
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Clear_ClearRingBufferWithSomeNumbersShouldWork()
        {
            // Arrange
            RingBufferArray<int> sut = new RingBufferArray<int>(10);
            int expected = 0;

            // Act
            sut.Add(int.MaxValue);
            sut.Add(int.MinValue);
            sut.Add(42);
            sut.Clear();
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_RingBuferShouldOverwriteWhenItFull()
        {
            // Arrange
            RingBufferArray<int> sut = new RingBufferArray<int>(7);
            int expected = 1;

            // Act
            for (int i = 0; i < 8; i++)
            {
                sut.Add(i);
            }
            int actual = sut.Get();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Get_GetFromEmptyRingBufferShouldNotWork()
        {
            // Arrange
            RingBufferArray<int> sut = new RingBufferArray<int>(10);

            // Act
            sut.Add(42);
            sut.Get();

            // Assert
            Assert.Throws<InvalidOperationException>(()=>sut.Get());
        }

        [Fact]
        public void Get_GetAllNumbersFromRingBufferShouldWork()
        {
            // Arrange
            RingBufferArray<int> sut = new RingBufferArray<int>(10);
            int expected = 0;

            // Act
            for (int i = 0; i < 20; i++)
            {
                sut.Add(i);
            }
            for (int i = 0; i <= 10; i++)
            {
                sut.Get();
            }
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void RingBufferArray_CreateRingBufferWithNegativeSizeShouldNotWork()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new RingBufferArray<int>(-1));
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange 
            RingBufferArray<double> sut = new RingBufferArray<double>(10);
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
            RingBufferArray<double> sut = new RingBufferArray<double>(10);
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
            RingBufferArray<double> sut = new RingBufferArray<double>(10);
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }
    }
}