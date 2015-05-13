using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_not
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_not_equal()
            {
                Action ensuring = () => Ensure.Value(1).Not(0);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_InvalidOperationException_is_thrown_by_default_if_the_value_is_equal()
            {
                Action ensuring = () => Ensure.Value(1).Not(1);
                ensuring.ShouldThrow<InvalidOperationException>().WithMessage("Cannot be 1.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(1).Not(1, "foo");
                ensuring.ShouldThrow<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(1).Not(1, _ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Value(new object());
                theEnsurable.NotNull().Should().Be(theEnsurable);
            }    
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_argument_is_not_equal()
            {
                Action ensuring = () => Ensure.Argument(1).Not(0);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_ArgumentException_is_thrown_by_default_if_the_argument_is_equal()
            {
                Action ensuring = () => Ensure.Argument(1).Not(1);
                ensuring.ShouldThrow<ArgumentException>().WithMessage("Cannot be 1.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).Not(1, "foo");
                ensuring.ShouldThrow<ArgumentException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).Not(1, _ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(new object());
                theEnsurable.NotNull().Should().Be(theEnsurable);
            }
        }
    }
}
