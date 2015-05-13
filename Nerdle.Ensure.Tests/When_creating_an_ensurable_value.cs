using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_creating_an_ensurable_value
    {
        [Test]
        public void The_value_is_set()
        {
            Ensure.Value(1).Should().Match(value => (Ensurable<int>)value == 1);
        }
    }
}
