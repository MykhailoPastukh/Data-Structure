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
            QueueLinkedList sut = new QueueLinkedList();
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
            QueueLinkedList sut = new QueueLinkedList();
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
            QueueLinkedList sut = new QueueLinkedList();
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
            QueueLinkedList sut = new QueueLinkedList();

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
            QueueLinkedList sut = new QueueLinkedList();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }
    }
}