using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_in
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_contained_in_the_collection()
            {
                Action ensuring = () => Ensure.Value(1).In(new[] { 1, 2, 3 });
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void Handles_non_generic_collections()
            {
                Action ensuring = () => Ensure.Value(DayOfWeek.Friday).In(Enum.GetValues(typeof (DayOfWeek)));
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void
                An_InvalidOperationException_is_thrown_by_default_if_the_value_is_not_contained_in_the_collection()
            {
                Action ensuring = () => Ensure.Value(0).In(new[] { 1, 2, 3 });
                ensuring.ShouldThrowExactly<InvalidOperationException>()
                    .WithMessage("Value was not contained in the specified collection.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(99).In(new[] { 1, 2, 3 }, "banana");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("banana");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(0).In(new[] { 1, 2, 3 }, _ => new IOException("oh no io"));
                ensuring.ShouldThrowExactly<IOException>().WithMessage("oh no io");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Value(1).In(new[] { 1, 2, 3 });
                theEnsurable.Not(0).Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_value_is_contained_in_the_collection()
            {
                Action ensuring = () => Ensure.Argument(1).In(new[] { 1, 2, 3 });
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void Handles_non_generic_collections()
            {
                Action ensuring = () => Ensure.Argument(DayOfWeek.Friday).In(Enum.GetValues(typeof(DayOfWeek)));
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_ArgumentException_is_thrown_by_default_if_the_value_is_not_contained_in_the_collection()
            {
                Action ensuring = () => Ensure.Argument(0).In(new[] { 1, 2, 3 });
                ensuring.ShouldThrowExactly<ArgumentException>()
                    .WithMessage("Value was not contained in the specified collection.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(99).In(new[] { 1, 2, 3 }, "banana");
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("banana");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Action ensuring = () => Ensure.Argument(0, "myArg").In(new[] { 1, 2, 3 });
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("myArg");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Action ensuring = () => Ensure.Argument(0).In(new[] { 1, 2, 3 });
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(0).In(new[] { 1, 2, 3 }, _ => new IOException("oh no io"));
                ensuring.ShouldThrowExactly<IOException>().WithMessage("oh no io");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(1).In(new[] { 1, 2, 3 });
                theEnsurable.Not(0).Should().Be(theEnsurable);
            }
        }
    }
}
