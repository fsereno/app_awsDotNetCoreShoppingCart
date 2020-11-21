using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Utils;
using Models;

namespace Utils.Tests
{
    public class BasketUtilTests
    {
        private IBasketUtil _sut;

        private Mock<ILogger<BasketUtil>> _logger;

        public BasketUtilTests()
        {
            _logger = new Mock<ILogger<BasketUtil>>();
            _sut = new BasketUtil(_logger.Object);
        }

        [Fact]
        public void Test_IsInRange_Happy_Test()
        {
            var position = 0;
            var collection = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" }
            };
            var result = _sut.TryRange(2, collection, out position);
            Assert.True(result);
            Assert.Equal(1, position);
        }

        [Fact]
        public void Test_IsInRange_UnHappy_Test()
        {
            var position = 0;
            var collection = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" }
            };
            var result = _sut.TryRange(3, collection, out position);
            Assert.False(result);
            Assert.Equal(2, position);
        }

        [Fact]
        public void Test_IsInRange_Zero_Index()
        {
            var position = 0;
            var collection = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" }
            };
            var result = _sut.TryRange(0, collection, out position);
            Assert.False(result);
            Assert.Equal(-1, position);
        }

        [Fact]
        public void Test_IsInRange_Empty_Collection()
        {
            var position = 0;
            var collection = new List<Item>();
            var result = _sut.TryRange(1, collection, out position);
            Assert.False(result);
            Assert.Equal(-1, position);
        }

        [Fact]
        public void Test_GetItems_EmptyRequest()
        {
            var requestItems = new List<Item>();
            var localItems = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" }
            };
            var result = _sut.GetItems(requestItems, localItems);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Test_GetItems_EmptyLocal()
        {
            var requestItems = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" },
                new Item() { Name = "Pear" }
            };
            var localItems = new List<Item>();
            var result = _sut.GetItems(requestItems, localItems);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Test_GetItems_GreaterThan()
        {
            var requestItems = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" },
                new Item() { Name = "Pear" }
            };
            var localItems = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" }
            };
            var result = _sut.GetItems(requestItems, localItems);
            Assert.Equal(3, result.Count);
        }
    }
}