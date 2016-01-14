using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_ensuring_type_attributes
    {
        [TestFixture]
        public class On_a_type
        {
            readonly TestClass _testClass = new TestClass();

            [Test]
            public void No_exception_is_thrown_if_the_type_has_the_attribute()
            {
                Action ensuring = () => Ensure.TypeOf(_testClass).HasAttribute<SerializableAttribute>();
                ensuring.ShouldNotThrow();
            }

            public void The_attribute_can_be_a_custom_attribute()
            {
                Action ensuring = () => Ensure.TypeOf(_testClass).HasAttribute<CustomAttribute>();
                ensuring.ShouldNotThrow();
            }

            [Test]
            public void An_exception_is_thrown_if_the_type_does_not_have_the_attribute()
            {
                Action ensuring = () => Ensure.TypeOf(_testClass).HasAttribute<FlagsAttribute>();
                ensuring.ShouldThrow<Exception>();
            }

            [Test]
            public void The_default_exception_is_InvalidOperationException()
            {
                Action ensuring = () => Ensure.TypeOf("foo").HasAttribute<ThreadStaticAttribute>();
                ensuring.ShouldThrowExactly<InvalidOperationException>()
                    .WithMessage("Type System.String does not have attribute System.ThreadStaticAttribute.");
            }

            [Test]
            public void A_custom_message_can_be_specified()
            {
                Action ensuring = () => Ensure.TypeOf(ConsoleColor.Red).HasAttribute<CustomAttribute>("wub wub wub");
                ensuring.ShouldThrowExactly<InvalidOperationException>().WithMessage("wub wub wub");
            }

            [Test]
            public void A_custom_exception_can_be_specified()
            {
                Action ensuring = () => Ensure.TypeOf('x').HasAttribute<ObsoleteAttribute>(_ => new NotSupportedException("qwerty"));
                ensuring.ShouldThrowExactly<NotSupportedException>().WithMessage("qwerty");
            }

            [Test]
            public void The_ensurable_is_returned()
            {
                var theEnsurable = Ensure.TypeOf(_testClass);
                theEnsurable.HasAttribute<SerializableAttribute>().Should().Be(theEnsurable);
            }
        }

        [Serializable]
        [Custom]
        class TestClass
        {}

        class CustomAttribute : Attribute
        {}
    }
}