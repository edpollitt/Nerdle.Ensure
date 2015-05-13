using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_generating_default_exceptions
    {
        [TestFixture]
        public class From_a_value
        {
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

        [TestFixture]
        public class From_an_argument
        {
            [Test]
            public void The_default_exception_type_is_ArgumentException()
            {
                Ensure.Argument(1).DefaultException(string.Empty).Should()
                    .BeOfType<ArgumentException>();
            }

            [Test]
            public void The_exception_message_can_be_set()
            {
                Ensure.Argument(1).DefaultException("foo bar baz").Should()
                    .BeOfType<ArgumentException>()
                    .Which.Message.Should().Be("foo bar baz");
            }

            [Test]
            public void The_exception_message_can_be_formatted()
            {
                Ensure.Argument(1).DefaultException("{0} {1} {2}", 3, "blind", "mice").Should()
                    .BeOfType<ArgumentException>()
                    .Which.Message.Should().Be("3 blind mice");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Ensure.Argument(1, "one").DefaultException("foo bar baz").Should()
                    .BeOfType<ArgumentException>()
                    .Which.ParamName.Should().Be("one");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Ensure.Argument(1).DefaultException("foo bar baz").Should()
                    .BeOfType<ArgumentException>()
                    .Which.ParamName.Should().BeNull();
            }
        }
    }
}