using NUnit.Framework;
using System;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.NUnitTests.Exercises
{
    [TestFixture]
    public class StackUnitTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Count_WhenStackEmpty_CountIsZero()
        {
            Assert.AreEqual(_stack.Count, 0);
            //Assert.AreEqual(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Push_ObjectIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws< ArgumentNullException>(()=>_stack.Push(null));
        }

        [Test]
        [TestCase("a")]
        public void Push_ObjectNotNull_AddTheObjInTheStack(string obj)
        {

            _stack.Push(obj);

            Assert.That(_stack.Count > 0);

            Assert.That(_stack.Pop(), Is.EqualTo("a"));
        }

        [Test]
        public void Pop_StackEmpty_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Pop());
        }

        [Test]
        public void Pop_StackNotEmpty_ReturnsTheLastElement()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            var result = _stack.Pop();

            Assert.That(result, Is.EqualTo("c"));
            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_StackEmpty_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _stack.Peek());
        }

        [Test]
        public void Peek_StackNotEmpty_ReturnTheLastElement()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
