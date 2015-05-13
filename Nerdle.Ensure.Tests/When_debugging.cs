using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;

namespace Nerdle.Ensure.Tests
{
    [TestFixture]
    public class When_debugging
    {
        [Test]
        public void All_classes_are_stepped_through()
        {
            var types = typeof (Ensure).Assembly.GetTypes();
            var decoratedTypes = types.ThatAreDecoratedWith<DebuggerStepThroughAttribute>();
            decoratedTypes.ShouldAllBeEquivalentTo(types);
        }
    }
}
