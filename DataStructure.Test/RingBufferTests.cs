using System;
using Xunit;

namespace DataStructure.Test
{
    public class RingBufferTests
    {
        [Fact]
        public void Add_AddSomeNumbersToRingBufferShouldWork()
        {
            // Arrange
            RingBuffer sut = new RingBuffer(3);
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
            RingBuffer sut = new RingBuffer(5);

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
            RingBuffer sut = new RingBuffer(100);
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
            RingBuffer sut = new RingBuffer(5);

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }

        [Fact]
        public void Get_AddAndGetSomeNumbersShouldWork()
        {
            // Arrange
            RingBuffer sut = new RingBuffer(5);
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
            Assert.Throws<ArgumentException>(()=>new RingBuffer(-2));
        }

        [Fact]
        public void Expand_ExpandRingBufferShouldWork()
        {
            // Arrange
            RingBuffer sut = new RingBuffer(3);
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
    }
}
