using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_a_string_is_not_null_or_empty
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_string_is_not_null_or_empty()
            {
                Action ensuring = () => Ensure.ValueOf("foo").NotNullOrEmpty();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_null()
            {
                Action ensuring = () => Ensure.ValueOf((string)null).NotNullOrEmpty();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_empty()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).NotNullOrEmpty();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void No_exception_is_thrown_if_the_string_is_white_space()
            {
                Action ensuring = () => Ensure.ValueOf("   ").NotNullOrEmpty();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).NotNullOrEmpty();
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).NotNullOrEmpty("foo");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).NotNullOrEmpty(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.ValueOf("hello");
                theEnsurable.NotNullOrEmpty().Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_string_is_not_null_or_empty()
            {
                Action ensuring = () => Ensure.Argument("foo").NotNullOrEmpty();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_null()
            {
                Action ensuring = () => Ensure.Argument((string)null).NotNullOrEmpty();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_empty()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).NotNullOrEmpty();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void No_exception_is_thrown_if_the_string_is_white_space()
            {
                Action ensuring = () => Ensure.Argument("   ").NotNullOrEmpty();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void The_default_exception_is_ArgumentException()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).NotNullOrEmpty();
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).NotNullOrEmpty("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("foo");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Action ensuring = () => Ensure.Argument(string.Empty, "myArg").NotNullOrEmpty("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("myArg");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).NotNullOrEmpty("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).NotNullOrEmpty(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument("hello");
                theEnsurable.NotNullOrEmpty().Should().Be(theEnsurable);
            }
        }
    }
}
