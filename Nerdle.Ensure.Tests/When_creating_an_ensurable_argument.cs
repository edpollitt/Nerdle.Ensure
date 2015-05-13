using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_creating_an_ensurable_argument
    {
        [Test]
        public void The_value_is_set()
        {
            Ensure.Argument(1).Should().Match(arg => (Ensurable<int>)arg == 1);
        }

        [Test]
        public void The_name_is_set()
        {
            Ensure.Argument(1, "name").Name.Should().Be("name");
        }

        [Test]
        public void The_name_is_optional()
        {
            Ensure.Argument(1).Name.Should().BeNull();
        }

        [Test]
        public void The_name_and_value_can_be_derived_from_a_lambda()
        {
            var theTimeNow = DateTime.Now;
            Ensure.Argument(() => theTimeNow).Should()
                .Match(arg => (Ensurable<DateTime>)arg == theTimeNow && ((EnsurableArgument<DateTime>)arg).Name == "theTimeNow");
        }

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