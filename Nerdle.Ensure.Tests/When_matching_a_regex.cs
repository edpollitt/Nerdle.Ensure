using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_matching_a_regex
    {
        [TestFixture]
        public class On_a_value
        {
            [TestFixture]
            public class When_supplying_a_regex_object
            {
                [Test]
                public void No_exception_is_thrown_if_the_regex_is_a_match()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(new Regex("^.*baz$"));
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_regex_is_not_a_match()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(new Regex(".*[0-9]"));
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_InvalidOperationException()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(new Regex(".*[0-9]"));
                    ensuring.ShouldThrowExactly<InvalidOperationException>()
                        .WithMessage("'foobarbaz' does not match the required regex '.*[0-9]'.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(new Regex(".*[0-9]"), "foo");
                    ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(new Regex(".*[0-9]"), _ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Value("foobarbaz");
                    theEnsurable.Matches(new Regex(".*")).Should().Be(theEnsurable);
                }
            }

            [TestFixture]
            public class When_supplying_a_string_pattern
            {
                [Test]
                public void No_exception_is_thrown_if_the_regex_is_a_match()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches("^.*baz$");
                    ensuring.ShouldNotThrow();
                }

                 [Test]
                public void An_exception_is_thrown_if_the_regex_is_not_a_match()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(".*[0-9]");
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_InvalidOperationException()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(".*[0-9]");
                    ensuring.ShouldThrowExactly<InvalidOperationException>()
                        .WithMessage("'foobarbaz' does not match the required regex '.*[0-9]'.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(".*[0-9]", "foo");
                    ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Value("foobarbaz").Matches(".*[0-9]", _ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Value("foobarbaz");
                    theEnsurable.Matches(new Regex(".*")).Should().Be(theEnsurable);
                }
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [TestFixture]
            public class When_supplying_a_regex_object
            {
                [Test]
                public void No_exception_is_thrown_if_the_regex_is_a_match()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(new Regex("^.*baz$"));
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_regex_is_not_a_match()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(new Regex(".*[0-9]"));
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_ArgumentException()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(new Regex(".*[0-9]"));
                    ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("'foobarbaz' does not match the required regex '.*[0-9]'.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(new Regex(".*[0-9]"), "foo");
                    ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("foo");
                }

                [Test]
                public void The_exception_includes_the_name_if_set()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz", "myArg").Matches(new Regex(".*[0-9]"), "foo");
                    ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("myArg");
                }

                [Test]
                public void The_exception_does_not_include_the_name_if_not_set()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(new Regex(".*[0-9]"), "foo");
                    ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz")
                        .Matches(new Regex(".*[0-9]"), _ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Argument("foobarbaz");
                    theEnsurable.Matches(new Regex(".*")).Should().Be(theEnsurable);
                }
            }

            [TestFixture]
            public class When_supplying_a_string_pattern
            {
                [Test]
                public void No_exception_is_thrown_if_the_regex_is_a_match()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches("^.*baz$");
                    ensuring.ShouldNotThrow();
                }

                [Test]
                public void An_exception_is_thrown_if_the_regex_is_not_a_match()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(".*[0-9]");
                    ensuring.ShouldThrow<Exception>();
                }

                [Test]
                public void The_default_exception_is_ArgumentException()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(".*[0-9]");
                    ensuring.ShouldThrowExactly<ArgumentException>()
                        .WithMessage("'foobarbaz' does not match the required regex '.*[0-9]'.");
                }

                [Test]
                public void A_custom_message_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(".*[0-9]", "foo");
                    ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("foo");
                }

                [Test]
                public void The_exception_includes_the_name_if_set()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz", "myArg").Matches(".*[0-9]", "foo");
                    ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("myArg");
                }

                [Test]
                public void The_exception_does_not_include_the_name_if_not_set()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz").Matches(".*[0-9]", "foo");
                    ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
                }

                [Test]
                public void A_custom_exception_can_be_specified()
                {
                    Action ensuring = () => Ensure.Argument("foobarbaz")
                        .Matches(".*[0-9]", _ => new IndexOutOfRangeException("bar"));
                    ensuring.ShouldThrowExactly<IndexOutOfRangeException>().WithMessage("bar");
                }

                [Test]
                public void The_ensurable_is_returned()
                {
                    var theEnsurable = Ensure.Argument("foobarbaz");
                    theEnsurable.Matches(new Regex(".*")).Should().Be(theEnsurable);
                }
            }
        }
    }
}
