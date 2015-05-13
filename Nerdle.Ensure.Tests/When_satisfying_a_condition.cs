using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_satisfying_a_condition
    {
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
                ensuring.ShouldThrow<InvalidOperationException>().WithMessage("Did not satisfy the predicate condition");
            }

            [Test]
            public void A_specific_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(1).Satisfies(x => false, _ => new IndexOutOfRangeException("foo"));
                ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("foo");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var result = Ensure.Value(1).Satisfies(x => true);
                result.Should().BeOfType<EnsurableValue<int>>();
                result.Value.Should().Be(1);
            }
        }


        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_condition_is_met()
            {
                Action ensuring = () => Ensure.Argument(1).Satisfies(x => true);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_InvalidOperationException_is_thrown_by_default_if_the_condition_is_not_met()
            {
                Action ensuring = () => Ensure.Argument(1).Satisfies(x => false);
                ensuring.ShouldThrow<ArgumentException>().WithMessage("Did not satisfy the predicate condition");
            }

            [Test]
            public void A_specific_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).Satisfies(x => false, _ => new IndexOutOfRangeException("foo"));
                ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("foo");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var result = Ensure.Argument(1).Satisfies(x => true);
                result.Should().BeOfType<EnsurableArgument<int>>();
                result.Value.Should().Be(1);
            }
        }
    }
}
