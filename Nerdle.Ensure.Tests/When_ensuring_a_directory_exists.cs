using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_a_directory_exists
    {
        [TestFixture]
        public class On_a_value
        {
            [Test]
            public void No_exception_is_thrown_if_the_directory_exists()
            {
                var directory = Directory.GetCurrentDirectory();
                Action ensuring = () => Ensure.ValueOf(directory).DirectoryExists();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_directory_does_not_exist()
            {
                Action ensuring = () => Ensure.ValueOf(@"Z:\foo\bar\baz").DirectoryExists();
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.ValueOf(@"Z:\foo\bar\baz").DirectoryExists();
                ensuring.ShouldThrowExactly<InvalidOperationException>()
                    .WithMessage(@"Directory 'Z:\foo\bar\baz' does not exist.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(@"Z:\foo\bar\baz").DirectoryExists("banana");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("banana");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.ValueOf(@"Z:\foo\bar\baz").DirectoryExists(dir => new IOException(dir));
                ensuring.ShouldThrowExactly<IOException>().WithMessage(@"Z:\foo\bar\baz");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var directory = Directory.GetCurrentDirectory();
                var theEnsurable = Ensure.ValueOf(directory);
                theEnsurable.DirectoryExists().Should().Be(theEnsurable);
            }
        }

        [TestFixture]
        public class On_an_argument
        {
            [Test]
            public void No_exception_is_thrown_if_the_directory_exists()
            {
                var directory = Directory.GetCurrentDirectory();
                Action ensuring = () => Ensure.Argument(directory).DirectoryExists();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_directory_does_not_exist()
            {
                Action ensuring = () => Ensure.Argument(@"Z:\foo\bar\baz").DirectoryExists();
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void The_default_exception_is_ArgumentException()
            {
                Action ensuring = () => Ensure.Argument(@"Z:\foo\bar\baz").DirectoryExists();
                ensuring.ShouldThrowExactly<ArgumentException>()
                    .WithMessage(@"Directory 'Z:\foo\bar\baz' does not exist.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(@"Z:\foo\bar\baz").DirectoryExists("jobbiedo");
                ensuring.ShouldThrowExactly<ArgumentException>().WithMessage("jobbiedo");
            }

            [Test]
            public void The_exception_includes_the_name_if_set()
            {
                Action ensuring = () => Ensure.Argument(@"Z:\foo\bar\baz", "directory").DirectoryExists("jobbiedo");
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().Be("directory");
            }

            [Test]
            public void The_exception_does_not_include_the_name_if_not_set()
            {
                Action ensuring = () => Ensure.Argument(@"Z:\foo\bar\baz").DirectoryExists("jobbiedo");
                ensuring.ShouldThrowExactly<ArgumentException>().And.ParamName.Should().BeNull();
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.Argument(@"Z:\foo\bar\baz").DirectoryExists(dir => new IOException(dir));
                ensuring.ShouldThrowExactly<IOException>().WithMessage(@"Z:\foo\bar\baz");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var directory = Directory.GetCurrentDirectory();
                var theEnsurable = Ensure.Argument(directory);
                theEnsurable.DirectoryExists().Should().Be(theEnsurable);
            }
        }
    }
}