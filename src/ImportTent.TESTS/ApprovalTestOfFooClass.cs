using ApprovalTests;
using ApprovalTests.Reporters;
using ImportTent.Lib;
using NUnit.Framework;

namespace ImportTent.TESTS
{
    [TestFixture]
    class ApprovalTestOfFooClass
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void FailingTest()
        {
            var sut = new FooClass();

            Approvals.Verify(sut.GetHello());
        }
    }
}
