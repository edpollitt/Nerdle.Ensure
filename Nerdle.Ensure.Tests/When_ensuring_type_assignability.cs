using System;
using System.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_type_assignability
    {
        [TestFixture]
        public class On_a_value
        {
            [TestFixture]
            public class When_both_types_are_classes
            {
                [Test]
                public void No_exception_is_thrown_if_the_type_is_the_same()
                {
                    Action ensuring = () => Ensure.Value(typeof(int)).IsAssignableTo<int>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void No_exception_is_thrown_if_the_type_is_a_subtype()
                {
                    Action ensuring = () => Ensure.Value(typeof(int)).IsAssignableTo<ValueType>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_type_is_not_the_same_or_a_subtype()
                {
                    Action ensuring = () => Ensure.Value(typeof(ValueType)).IsAssignableTo<int>();
                    ensuring.ShouldThrow<Exception>();
                }
            }

            [TestFixture]
            public class When_the_target_type_is_an_interface
            {
                [Test]
                public void No_exception_is_thrown_if_the_type_implements_the_interface()
                {
                    Action ensuring = () => Ensure.Value(typeof(int)).IsAssignableTo<IFormattable>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_type_does_not_implement_the_interface()
                {
                    Action ensuring = () => Ensure.Value(typeof(int)).IsAssignableTo<IEnumerable>();
                    ensuring.ShouldThrow<Exception>();
                }
            }

            [TestFixture]
            public class When_both_types_are_interfaces
            {
                [Test]
                public void No_exception_is_thrown_if_the_type_is_the_same()
                {
                    Action ensuring = () => Ensure.Value(typeof(IConvertible)).IsAssignableTo<IConvertible>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void No_exception_is_thrown_if_the_type_is_a_sub_interface()
                {
                    Action ensuring = () => Ensure.Value(typeof(ICollection)).IsAssignableTo<IEnumerable>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_type_is_not_the_same_or_a_sub_interface()
                {
                    Action ensuring = () => Ensure.Value(typeof(IEnumerable)).IsAssignableTo<ICollection>();
                    ensuring.ShouldThrow<Exception>();
                }
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.Value(typeof(int)).IsAssignableTo<long>();
                ensuring.ShouldThrowExactly<InvalidOperationException>()
                    .WithMessage("Type System.Int32 is not assignable to type System.Int64.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(typeof(int)).IsAssignableTo<double>("foo");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(typeof(int)).IsAssignableTo<double>(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Value(typeof(ushort));
                theEnsurable.IsAssignableTo<IComparable>().Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [TestFixture]
            public class When_both_types_are_classes
            {
                [Test]
                public void No_exception_is_thrown_if_the_type_is_the_same()
                {
                    Action ensuring = () => Ensure.Argument(typeof(DayOfWeek)).IsAssignableTo<DayOfWeek>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void No_exception_is_thrown_if_the_type_is_a_subtype()
                {
                    Action ensuring = () => Ensure.Argument(typeof(DayOfWeek)).IsAssignableTo<Enum>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_type_is_not_the_same_or_a_subtype()
                {
                    Action ensuring = () => Ensure.Argument(typeof(ValueType)).IsAssignableTo<int>();
                    ensuring.ShouldThrow<Exception>();
                }
            }

            [TestFixture]
            public class When_the_target_type_is_an_interface
            {
                [Test]
                public void No_exception_is_thrown_if_the_type_implements_the_interface()
                {
                    Action ensuring = () => Ensure.Argument(typeof(int)).IsAssignableTo<IFormattable>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_type_does_not_implement_the_interface()
                {
                    Action ensuring = () => Ensure.Argument(typeof(int)).IsAssignableTo<IEnumerable>();
                    ensuring.ShouldThrow<Exception>();
                }
            }

            [TestFixture]
            public class When_both_types_are_interfaces
            {
                [Test]
                public void No_exception_is_thrown_if_the_type_is_the_same()
                {
                    Action ensuring = () => Ensure.Argument(typeof(IConvertible)).IsAssignableTo<IConvertible>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void No_exception_is_thrown_if_the_type_is_a_sub_interface()
                {
                    Action ensuring = () => Ensure.Argument(typeof(ICollection)).IsAssignableTo<IEnumerable>();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_type_is_not_the_same_or_a_sub_interface()
                {
                    Action ensuring = () => Ensure.Argument(typeof(IEnumerable)).IsAssignableTo<ICollection>();
                    ensuring.ShouldThrow<Exception>();
                }
            }

            [Test]
            public void The_default_exception_is_ArgumentException()
            {
                Action ensuring = () => Ensure.Argument(typeof(int)).IsAssignableTo<long>();
                ensuring.ShouldThrowExactly<ArgumentException>()
                    .WithMessage("Type System.Int32 is not assignable to type System.Int64.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(typeof(int)).IsAssignableTo<double>("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(typeof(int)).IsAssignableTo<double>(_ => new IndexOutOfRangeException("bar"));
                ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(typeof(ushort));
                theEnsurable.IsAssignableTo<IComparable>().Should().Be(theEnsurable);
            }
        }
    }
}
