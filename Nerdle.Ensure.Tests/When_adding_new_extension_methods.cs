using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_adding_new_extension_methods
    {
        [Test]
        public void All_types_should_be_in_the_base_namespace_to_make_things_easy_for_consumers()
        {
            var types = typeof(Ensure).Assembly.GetTypes().Where(type => !type.IsNestedPrivate).ToList();
            var namespaces = types.Select(type => type.Namespace).Distinct().ToList();
            namespaces.Should().HaveCount(1);
            namespaces.Single().Should().Be("Nerdle.Ensure");
        }
    }
}