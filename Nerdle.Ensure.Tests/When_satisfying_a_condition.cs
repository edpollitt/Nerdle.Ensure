using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_satisfying_a_condition
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_condition_is_met()
            {
                Action ensuring = () => Ensure.Value(1).Satisfies(x => true);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_InvalidOperationException_is_thrown_by_default_if_the_condition_is_not_met()
            {
                Action ensuring = () => Ensure.Value(1).Satisfies(x => false);
                ensuring.ShouldThrow<InvalidOperationException>().WithMessage("Did not satisfy the predicate condition.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(1).Satisfies(x => false, "foo");
                ensuring.ShouldThrow<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(1).Satisfies(x => false, y => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(1);
                theEnsurable.Satisfies(x => true).Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_condition_is_met()
            {
                Action ensuring = () => Ensure.Argument(1).Satisfies(x => true);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_ArgumentException_is_thrown_by_default_if_the_condition_is_not_met()
            {
                Action ensuring = () => Ensure.Argument(1).Satisfies(x => false);
                ensuring.ShouldThrow<ArgumentException>().WithMessage("Did not satisfy the predicate condition.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).Satisfies(x => false, "foo");
                ensuring.ShouldThrow<ArgumentException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).Satisfies(x => false, _ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(1);
                theEnsurable.Satisfies(x => true).Should().Be(theEnsurable);
            }
        }
    }
}
