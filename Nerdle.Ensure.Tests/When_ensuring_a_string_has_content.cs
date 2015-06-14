using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_a_string_has_content
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_string_has_content()
            {
                Action ensuring = () => Ensure.ValueOf("foo").HasContent();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_null()
            {
                Action ensuring = () => Ensure.ValueOf((string)null).HasContent();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_empty()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).HasContent();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_white_space()
            {
                Action ensuring = () => Ensure.ValueOf("   ").HasContent();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).HasContent();
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).HasContent("foo");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(string.Empty).HasContent(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.ValueOf("hello");
                theEnsurable.HasContent().Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_string_has_content()
            {
                Action ensuring = () => Ensure.Argument("foo").HasContent();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_null()
            {
                Action ensuring = () => Ensure.Argument((string)null).HasContent();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_empty()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).HasContent();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_string_is_white_space()
            {
                Action ensuring = () => Ensure.Argument("   ").HasContent();
                ensuring.ShouldThrow<Exception>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void The_default_exception_is_ArgumentException()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).HasContent();
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("Cannot be null or white space.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).HasContent("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("foo");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Action ensuring = () => Ensure.Argument(string.Empty, "myArg").HasContent("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("myArg");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).HasContent("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(string.Empty).HasContent(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument("hello");
                theEnsurable.HasContent().Should().Be(theEnsurable);
            }
        }
    }
}
