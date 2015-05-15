using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_not_default
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_not_default()
            {
                Action ensuring = () => Ensure.Value(1).NotDefault();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_default()
            {
                Action ensuring = () => Ensure.Value(0).NotDefault();
                ensuring.ShouldThrow<Exception>();
            }
            
            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.Value(Guid.Empty).NotDefault();
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("Cannot have default value.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(DateTime.MinValue).NotDefault("foo");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(0).NotDefault(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Value(1);
                theEnsurable.NotDefault().Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_not_default()
            {
                Action ensuring = () => Ensure.Argument(1).NotDefault();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_default()
            {
                Action ensuring = () => Ensure.Argument(0).NotDefault();
                ensuring.ShouldThrow<Exception>();
            }
            
            [Test]
            public void The_default_exception_is_ArgumentException()
            {
                Action ensuring = () => Ensure.Argument(Guid.Empty).NotDefault();
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("Cannot have default value.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(DateTime.MinValue).NotDefault("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("foo");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Action ensuring = () => Ensure.Argument(0, "myArg").NotDefault();
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("myArg");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Action ensuring = () => Ensure.Argument(0).NotDefault();
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(0).NotDefault(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(1);
                theEnsurable.NotDefault().Should().Be(theEnsurable);
            }
        }
    }
}