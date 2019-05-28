﻿using System;
using Xunit;

namespace DataStructure.Tests
{
    public class RingBufferArrayTests
    {
        [Fact]
        public void Enumerable_EnumShouldWork()
        {
            // Arrange
            RingBufferArray<int> sut = new RingBufferArray<int>(5);
            int[] arr = new int[3];

            // Act
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            int i = 0;
            foreach (var item in sut)
            {
                arr[i] = item;
                i++;
            }

            // Assert

            Assert.Equal(new int[] { 1, 2, 3 }, arr);
        }

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
            RingBufferArray<int> sut = new RingBufferArray<int>(10)
            {

                // Act
                42
            };
            sut.Get();

            // Assert
            Assert.Throws<DataStructureIsEmptyOnReadExeption>(()=>sut.Get());
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
            for (int i = 0; i < 5; i++)
            {
                sut.Get();
            }
            sut.Add(2);
            sut.Add(5);
            sut.Add(11);
            sut[7] = 42.2;
            double actual = sut[7];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_GetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            RingBufferArray<double> sut = new RingBufferArray<double>(10)
            {
                1,
                2
            };

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5]);
        }

        [Fact]
        public void Indexer_SetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            RingBufferArray<double> sut = new RingBufferArray<double>(10)
            {
                1,
                2
            };

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }
    }
}