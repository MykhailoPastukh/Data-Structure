using System;
using Xunit;

namespace DataStructure.Tests
{
    public class RingBufferLinkedListTests
    {
        [Fact]
        public void Add_AddSomeNumbersToRingBufferShouldWork()
        {
            // Arrange
            RingBufferLinkedList<int> sut = new RingBufferLinkedList<int>(3);
            int expected = 3;

            // Act
            sut.Add(11);
            sut.Add(12);
            sut.Add(13);
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Add_AddNumbersToFullRingBufferShouldNotWork()
        {
            // Arrange
            RingBufferLinkedList<int> sut = new RingBufferLinkedList<int>(5);

            // Act
            for (int i = 0; i < 5; i++)
            {
                sut.Add(i);
            }

            // Assert
            Assert.Throws<InvalidOperationException>(()=>sut.Add(6));
        }

        [Fact]
        public void Clear_ClearRingBufferShouldWork()
        {
            // Arrange
            RingBufferLinkedList<int> sut = new RingBufferLinkedList<int>(100);
            bool expected = true;

            // Act
            for (int i = 0; i < 100; i++)
            {
                sut.Add(i);
            }
            sut.Clear();
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Get_GetNumbersFromEmptyRingBufferShouldThrowExeption()
        {
            // Arrange
            RingBufferLinkedList<int> sut = new RingBufferLinkedList<int>(5);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }

        [Fact]
        public void Get_AddAndGetSomeNumbersShouldWork()
        {
            // Arrange
            RingBufferLinkedList<int> sut = new RingBufferLinkedList<int>(5);
            int expected = 42;

            // Act
            sut.Add(12);
            sut.Add(15);
            sut.Add(42);
            sut.Get();
            sut.Add(48);
            sut.Get();
            int actual = sut.Get();
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RingBuffer_CreateRingBufferWithNegativeSizeShouldThrowExeption()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentException>(()=>new RingBufferLinkedList<int>(-2));
        }

        [Fact]
        public void Expand_ExpandRingBufferShouldWork()
        {
            // Arrange
            RingBufferLinkedList<int> sut = new RingBufferLinkedList<int>(3);
            int expected = 5;

            // Act
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);
            sut.Expand(2);
            sut.Add(4);
            sut.Add(5);
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange 
            RingBufferLinkedList<double> sut = new RingBufferLinkedList<double>(10);
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
            RingBufferLinkedList<double> sut = new RingBufferLinkedList<double>(10);
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
            RingBufferLinkedList<double> sut = new RingBufferLinkedList<double>(10);
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
            RingBufferLinkedList<double> sut = new RingBufferLinkedList<double>(10);
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }
    }
}