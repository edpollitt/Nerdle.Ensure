using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_between
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_equal_to_the_lower_bound()
            {
                Action ensuring = () => Ensure.Value(1).Between(1, 100);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void No_exception_is_thrown_if_the_value_is_equal_to_the_upper_bound()
            {
                Action ensuring = () => Ensure.Value(100).Between(1, 100);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void No_exception_is_thrown_if_the_value_is_between_the_lower_and_upper_bounds()
            {
                Action ensuring = () => Ensure.Value(0).Between(-1, 1);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_less_than_the_lower_bound()
            {
                Action ensuring = () => Ensure.Value(0).Between(1, 10);
                ensuring.ShouldThrow<Exception>().WithMessage("Value must be between 1 and 10 but was 0.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_greater_than_the_upper_bound()
            {
                Action ensuring = () => Ensure.Value(11).Between(1, 10);
                 ensuring.ShouldThrow<Exception>().WithMessage("Value must be between 1 and 10 but was 11.");
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.Value(1).Between(-1, 0);
                ensuring.ShouldThrowExactly<InvalidOperationException>();
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(1).Between(-1, 0, "foo");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(1).Between(10, 100, _ => new FieldAccessException("bar"));
                ensuring.ShouldThrowExactly<FieldAccessException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Value(1);
                theEnsurable.Between(0, 1).Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_equal_to_the_lower_bound()
            {
                Action ensuring = () => Ensure.Argument(1).Between(1, 100);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void No_exception_is_thrown_if_the_value_is_equal_to_the_upper_bound()
            {
                Action ensuring = () => Ensure.Argument(100).Between(1, 100);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void No_exception_is_thrown_if_the_value_is_between_the_lower_and_upper_bounds()
            {
                Action ensuring = () => Ensure.Argument(0).Between(-1, 1);
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_less_than_the_lower_bound()
            {
                Action ensuring = () => Ensure.Argument(0).Between(1, 10);
                ensuring.ShouldThrow<Exception>().WithMessage("Value must be between 1 and 10 but was 0.");
            }

            [Test]
            public void An_exception_is_thrown_if_the_value_is_greater_than_the_upper_bound()
            {
                Action ensuring = () => Ensure.Argument(11).Between(1, 10);
                ensuring.ShouldThrow<Exception>().WithMessage("Value must be between 1 and 10 but was 11.");
            }

            [Test]
            public void The_default_exception_is_ArgumentOutOfRangeException()
            {
                Action ensuring = () => Ensure.Argument(1).Between(-1, 0);
                ensuring.ShouldThrowExactly<ArgumentOutOfRangeException>();
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).Between(-1, 0, "foo");
                ensuring.ShouldThrowExactly<ArgumentOutOfRangeException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(1).Between(10, 100, _ => new FileLoadException("bar"));
                ensuring.ShouldThrowExactly<FileLoadException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(1);
                theEnsurable.Between(0, 1).Should().Be(theEnsurable);
            }
        }
    }
}