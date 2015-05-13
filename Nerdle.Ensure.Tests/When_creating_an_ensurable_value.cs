using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_creating_an_ensurable_value
    {
        [Test]
        public void The_value_is_set()
        {
            Ensure.Value(1).Should().Match(value => (Ensurable<int>)value == 1);
        }

        [Test]
        public void The_default_exception_type_is_InvalidOperationException()
        {
            Ensure.Value(1).DefaultException(string.Empty).Should()
                .BeOfType<InvalidOperationException>();
        }

        [Test]
        public void The_exception_message_can_be_set()
        {
            Ensure.Value(1).DefaultException("foo bar baz").Should()
                .BeOfType<InvalidOperationException>()
                .Which.Message.Should().Be("foo bar baz");
        }

        [Test]
        public void The_exception_message_can_be_formatted()
        {
            Ensure.Value(1).DefaultException("{0} {1} {2}", 3, "blind", "mice").Should()
                .BeOfType<InvalidOperationException>()
                .Which.Message.Should().Be("3 blind mice");
        }
    }
}
