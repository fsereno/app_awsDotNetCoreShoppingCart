using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
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
        public void Test_IsInRange_Verify_Logging_Occurs()
        {
            var position = 0;
            var collection = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" }
            };
            var result = _sut.TryRange(2, collection, out position);
            VerifyLogger(LogLevel.Information, "Started checking index is in range");
            VerifyLogger(LogLevel.Information, "Finished checking index is in range");
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

        [Fact]
        public void Test_GetItems_Verify_Logging_Occurs()
        {
            var requestItems = new List<Item>()
            {
                new Item() { Name = "Apple" },
                new Item() { Name = "Banana" },
                new Item() { Name = "Pear" }
            };
            var localItems = new List<Item>();
            var result = _sut.GetItems(requestItems, localItems);
            VerifyLogger(LogLevel.Information, "Started getting itmes");
            VerifyLogger(LogLevel.Information, "Finished getting itmes");
        }

        private void VerifyLogger(LogLevel expectedLogLevel, string expectedMessage = "")
        {
            _logger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == expectedLogLevel),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => String.IsNullOrEmpty(expectedMessage) ? true : v.ToString() == expectedMessage),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));
        }
    }
}