using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_creating_an_ensurable_argument
    {
        [Test]
        public void The_value_is_set_and_can_be_explicitly_cast()
        {
            (Ensure.Argument(1) == 1).Should().BeTrue();
        }

        [Test]
        public void The_name_is_set()
        {
            Ensure.Argument(1, "name").Name.Should().Be("name");
        }

        [Test]
        public void The_name_is_optional()
        {
            Ensure.Argument(1).Name.Should().BeNull();
        }

        [Test]
        public void The_name_and_value_can_be_derived_from_a_lambda()
        {
            var theTimeNow = DateTime.Now;
            Ensure.Argument(() => theTimeNow).Should()
                .Match(arg => (Ensurable<DateTime>)arg == theTimeNow && ((EnsurableArgument<DateTime>)arg).Name == "theTimeNow");
        }

        [Test]
        public void The_ensurable_can_be_stringed_to_its_value_string()
        {
            Ensure.Argument(Guid.Empty).ToString().Should().Be(Guid.Empty.ToString());
        }
    }
}