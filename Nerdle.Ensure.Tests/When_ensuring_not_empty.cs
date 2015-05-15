using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_not_empty
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_collection_is_not_empty()
            {
                Action ensuring = () => Ensure.Value(new[] { 1 }).NotEmpty();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_collection_is_empty()
            {
                Action ensuring = () => Ensure.Value(Enumerable.Empty<int>()).NotEmpty();
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.Value(Enumerable.Empty<int>()).NotEmpty();
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("Collection must not be empty.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(Enumerable.Empty<int>()).NotEmpty("foo");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("foo");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Value(Enumerable.Empty<int>())
                    .NotEmpty(_ => new FileNotFoundException("bar"));
                ensuring.ShouldThrowExactly<FileNotFoundException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Value(new[] { 1 });
                theEnsurable.NotEmpty().Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_collection_is_not_empty()
            {
                Action ensuring = () => Ensure.Argument(new[] { 1 }).NotEmpty();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_collection_is_empty()
            {
                Action ensuring = () => Ensure.Argument(Enumerable.Empty<int>()).NotEmpty();
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void The_default_exception_is_ArgumentException()
            {
                Action ensuring = () => Ensure.Argument(Enumerable.Empty<int>()).NotEmpty();
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("Collection must not be empty.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(Enumerable.Empty<int>()).NotEmpty("foo");
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("foo");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Action ensuring = () => Ensure.Argument(Enumerable.Empty<int>(), "kajagoogoo").NotEmpty();
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("kajagoogoo");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Action ensuring = () => Ensure.Argument(Enumerable.Empty<int>()).NotEmpty();
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(Enumerable.Empty<int>())
                    .NotEmpty(_ => new FileNotFoundException("bar"));
                ensuring.ShouldThrowExactly<FileNotFoundException>().WithMessage("bar");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.Argument(new[] { 1 });
                theEnsurable.NotEmpty().Should().Be(theEnsurable);
            }
        }
    }
}
