﻿using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructure.Tests
{
    public class QueueLinkedListTests
    {
        [Fact]
        public void IsEmpty_EmptyQueueShouldReturnTrue()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
            bool expected = true;

            // Act
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Clear_ClearQueueWithSomeNumbersShoulWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
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

        [Theory]
        [InlineData(100)]
        [InlineData(100000)]
        public void Add_AddManyNumbersToQueueShouldWork(int count)
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
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

        [Fact]
        public void Get_GetNumbersFromQueueShouldWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                sut.Add(i);
            }

            // Assert
            for (int expected = 0; expected < 100; expected++)
            {
                Assert.Equal(expected, sut.Get());
            }
        }

        [Fact]
        public void Get_GetFromEmptyQueueShouldThrowExeption()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }

        [Fact]
        public void Indexer_IndexerGetAndSetShouldWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
            int expected = 42;

            // Act
            for (int i = 0; i < 10; i++)
            {
                sut.Add(i);
            }
            sut[5] = 42;
            int actual = sut[5];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_IndexerGetAndSetFromEndShouldWork()
        {
            // Arrange
            QueueLinkedList<int> sut = new QueueLinkedList<int>();
            int expected = 42;

            // Act
            for (int i = 0; i < 10; i++)
            {
                sut.Add(i);
            }
            sut[9] = 42;
            int actual = sut[9];

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_GetFromWrongIndexShouldThrowExeption()
        {
            // Arrange
            QueueLinkedList<double> sut = new QueueLinkedList<double>();
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
            QueueLinkedList<double> sut = new QueueLinkedList<double>();
            sut.Add(1);
            sut.Add(2);

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => sut[5] = 10);
        }
    }
}