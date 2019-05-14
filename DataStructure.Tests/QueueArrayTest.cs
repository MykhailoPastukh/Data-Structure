using System;
using Xunit;

namespace DataStructure.Tests
{
    public class QueueArrayTest
    {
        [Fact]
        public void IsEmpty_EmptyQueueShouldReturnTrue()
        {
            bool expected = true;

            QueueArray sut = new QueueArray();
            bool actual = sut.IsEmpty();

            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Clear_ClearQueueArrayWithSomeNumbersShoulWork()
        {
            QueueArray expected = new QueueArray();

            QueueArray sut = expected;
            sut.Add(int.MaxValue);
            sut.Add(int.MinValue);
            sut.Add(42);
            sut.Clear();

            Assert.Same(expected,sut);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(10000)]
        public void Add_AddManyNumbersToQueueArrayShouldWork(int count)
        {
            int expected = count;

            QueueArray sut = new QueueArray();
            for (int i = 0; i < count; i++)
            {
                sut.Add(i);
            }
            int actual = sut.Size();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100)]
        public void Get_GetNumbersFromQueueArrayShouldWork(int count)
        {
            QueueArray sut = new QueueArray();
            for (int i = 0; i < count; i++)
            {
                sut.Add(i);
            }

            for (int expected = 0; expected < count; expected++)
            {
                Assert.Equal(expected,sut.Get());
            }
        }

        [Fact]
        public void Get_GetFromEmptyQueueShouldNotWork()
        {
            QueueArray sut = new QueueArray();
            Assert.Throws<InvalidOperationException>(() => sut.Get());
        }
    }
}