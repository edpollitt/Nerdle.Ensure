using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_not_null
    {
        [TestFixture]
        public class On_a_value
        {
            [TestFixture]
            public class When_the_value_is_a_reference_type
            {
                [Test]
                public void No_exception_is_thrown_if_the_value_is_not_null()
                {
                    Action ensuring = () => Ensure.Value(new object()).NotNull();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_InvalidOperationException_is_thrown_by_default_if_the_value_is_null()
                {
                    Action ensuring = () => Ensure.Value((object)null).NotNull();
                    ensuring.ShouldThrow<InvalidOperationException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value((object)null).NotNull("foo");
                    ensuring.ShouldThrow<InvalidOperationException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value((object)null).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Argument(new object());
                    theEnsurable.NotNull().Should().Be(theEnsurable);
                }
            }

            [TestFixture]
            public class When_the_value_is_a_nullable_value_type
            {
                [Test]
                public void No_exception_is_thrown_if_the_value_is_not_null()
                {
                    Action ensuring = () => Ensure.Value((int?)1).NotNull();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_InvalidOperationException_is_thrown_by_default_if_the_value_is_null()
                {
                    Action ensuring = () => Ensure.Value((int?)null).NotNull();
                    ensuring.ShouldThrow<InvalidOperationException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value((int?)null).NotNull("foo");
                    ensuring.ShouldThrow<InvalidOperationException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value((int?)null).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Argument((int?)1);
                    theEnsurable.NotNull().Should().Be(theEnsurable);
                }
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [TestFixture]
            public class When_the_argument_is_a_reference_type
            {
                [Test]
                public void No_exception_is_thrown_if_the_argument_is_not_null()
                {
                    Action ensuring = () => Ensure.Argument(new object()).NotNull();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_ArgumentNullException_is_thrown_by_default_if_the_argument_is_null()
                {
                    Action ensuring = () => Ensure.Argument((object)null).NotNull();
                    ensuring.ShouldThrow<ArgumentNullException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((object)null).NotNull("foo");
                    ensuring.ShouldThrow<ArgumentNullException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((object)null).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Argument(new object());
                    theEnsurable.NotNull().Should().Be(theEnsurable);
                }
            }

            [TestFixture]
            public class When_the_argument_is_a_nullable_value_type
            {
                [Test]
                public void No_exception_is_thrown_if_the_argument_is_not_null()
                {
                    Action ensuring = () => Ensure.Argument((int?)1).NotNull();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_ArgumentNullException_is_thrown_by_default_if_the_argument_is_null()
                {
                    Action ensuring = () => Ensure.Argument((int?)null).NotNull();
                    ensuring.ShouldThrow<ArgumentNullException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((int?)null).NotNull("foo");
                    ensuring.ShouldThrow<ArgumentNullException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((int?)null).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrow<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Argument((int?)1);
                    theEnsurable.NotNull().Should().Be(theEnsurable);
                }
            }
        }
    }
}
