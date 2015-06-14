using System;
using System.Collections.Generic;
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
                    Action ensuring = () => Ensure.ValueOf(new object()).NotNull();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_value_is_null()
                {
                    Action ensuring = () => Ensure.ValueOf(new int?()).NotNull();
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_InvalidOperationException()
                {
                    Action ensuring = () => Ensure.ValueOf((object)null).NotNull();
                    ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.ValueOf((object)null).NotNull("foo");
                    ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.ValueOf(new DateTime?()).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.ValueOf(new object());
                    theEnsurable.NotNull().Should().Be(theEnsurable);
                }
            }

            [TestFixture]
            public class When_the_value_is_a_nullable_value_type
            {
                [Test]
                public void No_exception_is_thrown_if_the_value_is_not_null()
                {
                    Action ensuring = () => Ensure.ValueOf((int?)1).NotNull();
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_value_is_null()
                {
                    Action ensuring = () => Ensure.ValueOf((object)null).NotNull();
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_InvalidOperationException()
                {
                    Action ensuring = () => Ensure.ValueOf(new int?()).NotNull();
                    ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.ValueOf((string)null).NotNull("foo");
                    ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.ValueOf(new DateTime?()).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.ValueOf((int?)1);
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
                public void An_exception_is_thrown_if_the_value_is_null()
                {
                    Action ensuring = () => Ensure.Argument((object)null).NotNull();
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_ArgumentNullException()
                {
                    Action ensuring = () => Ensure.Argument((string)null).NotNull();
                    ensuring.ShouldThrowExactly<ArgumentNullException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((object)null).NotNull("foo");
                    ensuring.ShouldThrowExactly<ArgumentNullException>().WithMessage("foo");
                }

                [Test]
                public void The_exception_includes_the_name_if_set()
                {
                    Action ensuring = () => Ensure.Argument((List<int>)null, "myArg").NotNull();
                    ensuring.ShouldThrowExactly<ArgumentNullException>().And.ParamName.Should().Be("myArg");
                }

                [Test]
                public void The_exception_does_not_include_the_name_if_not_set()
                {
                    Action ensuring = () => Ensure.Argument((object)null).NotNull();
                    ensuring.ShouldThrowExactly<ArgumentNullException>().And.ParamName.Should().BeNull();
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((object)null).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
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
                public void An_exception_is_thrown_if_the_value_is_null()
                {
                    Action ensuring = () => Ensure.Argument(new int?()).NotNull();
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_ArgumentNullException()
                {
                    Action ensuring = () => Ensure.Argument(new DateTime?()).NotNull();
                    ensuring.ShouldThrowExactly<ArgumentNullException>().WithMessage("Cannot be null.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((int?)null).NotNull("foo");
                    ensuring.ShouldThrowExactly<ArgumentNullException>().WithMessage("foo");
                }

                [Test]
                public void The_exception_includes_the_name_if_set()
                {
                    Action ensuring = () => Ensure.Argument((int?)null, "myArg").NotNull();
                    ensuring.ShouldThrowExactly<ArgumentNullException>().And.ParamName.Should().Be("myArg");
                }

                [Test]
                public void The_exception_does_not_include_the_name_if_not_set()
                {
                    Action ensuring = () => Ensure.Argument((int?)null).NotNull();
                    ensuring.ShouldThrowExactly<ArgumentNullException>().And.ParamName.Should().BeNull();
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument((int?)null).NotNull(_ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
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
