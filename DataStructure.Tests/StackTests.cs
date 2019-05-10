using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;
using Xunit;

namespace DataStructure.Tests
{
    public class StackTests
    {
        [Fact]
        public void Size_EmptyStackShouldReturnZero()
        {
            // Arrange
            int expected = 0;

            // Act
            Stack sut = new Stack();
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_EmptyStackShouldReturnTrue()
        {
            // Arrange
            bool expected = true;

            // Act
            Stack sut = new Stack();
            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void Add_AddNodesToStackShouldWork(int count)
        {
            // Arrange
            int expected = count;

            // Act
            Stack sut = new Stack();
            for (int i = 0; i < count; i++)
            {
                Node node = new Node();
                node.SetItem(i);
                sut.Add(node);
            }
            int actual = sut.Size();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        //[InlineData(int.MaxValue)]
        public void Get_SetAndGetNodesShouldBeTheSame(int count)
        {
            // Arrange
            Node expected = new Node();
            expected.SetItem(42);

            // Act
            Stack sut = new Stack();
            sut.Add(expected);
            for (int i = 0; i < count; i++)
            {
                Node node = new Node();
                node.SetItem(i);
                sut.Add(node);
            }
            for (int i = 0; i < count; i++)
            {
                sut.Get();
            }
            Node actual = sut.Get();

            // Assert
            Assert.Same(expected, actual);
        }

        [Fact]
        public void Clear_ClearStackWithTwoNodesShouldWork()
        {
            // Arrange
            bool expected = true;

            // Act
            Stack sut = new Stack();

            Node firstNode = new Node();
            firstNode.SetItem(int.MaxValue);
            sut.Add(firstNode);

            Node secondNode = new Node();
            secondNode.SetItem(int.MinValue);
            sut.Add(secondNode);

            sut.Clear();

            bool actual = sut.IsEmpty();

            // Assert
            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(10)]
        public void Add_AddNullNodesShouldWork(int count)
        {
            // Arrange
            Stack sut = new Stack();           
            Node expected = null;

            // Act
            Node node = null;
            for (int i = 0; i < count; i++)
            {               
                sut.Add(node);                
            }
            for (int i = 0; i < count; i++)
            {                
                sut.Get();
            }
            Node actual = sut.Get();

            // Assert
            Assert.Same(expected, actual);
        }
    }
}