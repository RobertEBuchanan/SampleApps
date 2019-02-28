using Shouldly;
using ImportTent.Lib;
using NUnit.Framework;

namespace ImportTent.TESTS
{
    [TestFixture]
    public class ShouldyTestsOfFooClass
    {
        [Test]        
        public void FailingTest()
        {
            var sut = new FooClass();

            var result = sut.GetHello();

            result.ShouldBe("bad value");
        }
    }
}
