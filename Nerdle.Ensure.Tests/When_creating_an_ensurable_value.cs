using System;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_creating_an_ensurable_value
    {
        [Test]
        public void The_value_is_set_and_can_be_explicitly_cast()
        {
            (Ensure.ValueOf(1) == 1).Should().BeTrue();
        }

        [Test]
        public void The_ensurable_can_be_stringed_to_its_value_string()
        {
            Ensure.ValueOf(Guid.Empty).ToString().Should().Be(Guid.Empty.ToString());
        }
    }
}
