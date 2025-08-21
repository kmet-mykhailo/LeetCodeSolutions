using LeetcodeConsoleApp.Models;
using LeetcodeConsoleApp.Solutions;
using Xunit;

namespace LeetcodeConsoleApp.Tests
{
    public class AddTwoNumbersTests
    {
        private readonly AddTwoNumbersSolution _solution;

        public AddTwoNumbersTests()
        {
            _solution = new AddTwoNumbersSolution();
        }

        [Fact]
        public void AddTwoNumbers_BasicCase_ReturnsCorrectSum()
        {
            // Arrange: 342 + 465 = 807
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("7,0,8", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_DifferentLengths_ReturnsCorrectSum()
        {
            // Arrange: 9999999 + 9999 = 10009998
            var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("8,9,9,9,0,0,0,1", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_WithCarryOver_ReturnsCorrectSum()
        {
            // Arrange: 199 + 1 = 200
            var l1 = new ListNode(9, new ListNode(9, new ListNode(1)));
            var l2 = new ListNode(1);

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("0,0,2", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_BothSingleDigit_ReturnsCorrectSum()
        {
            // Arrange: 5 + 5 = 10
            var l1 = new ListNode(5);
            var l2 = new ListNode(5);

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("0,1", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_SingleDigitNoCarry_ReturnsCorrectSum()
        {
            // Arrange: 2 + 3 = 5
            var l1 = new ListNode(2);
            var l2 = new ListNode(3);

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("5", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_OneListNull_HandlesGracefully()
        {
            // Arrange: 1 + null = 1
            var l1 = new ListNode(1);
            ListNode l2 = null!;

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("1", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_LargeCarryChain_ReturnsCorrectSum()
        {
            // Arrange: 999 + 1 = 1000
            var l1 = new ListNode(9, new ListNode(9, new ListNode(9)));
            var l2 = new ListNode(1);

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("0,0,0,1", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_ZeroPlusZero_ReturnsZero()
        {
            // Arrange: 0 + 0 = 0
            var l1 = new ListNode(0);
            var l2 = new ListNode(0);

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("0", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_FirstListLonger_ReturnsCorrectSum()
        {
            // Arrange: 123 + 45 = 168
            var l1 = new ListNode(3, new ListNode(2, new ListNode(1)));
            var l2 = new ListNode(5, new ListNode(4));

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("8,6,1", result.ToString());
        }

        [Fact]
        public void AddTwoNumbers_SecondListLonger_ReturnsCorrectSum()
        {
            // Arrange: 45 + 123 = 168
            var l1 = new ListNode(5, new ListNode(4));
            var l2 = new ListNode(3, new ListNode(2, new ListNode(1)));

            // Act
            var result = _solution.AddTwoNumbers(l1, l2);

            // Assert
            Assert.Equal("8,6,1", result.ToString());
        }
    }
}
