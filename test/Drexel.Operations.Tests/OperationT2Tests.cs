using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Operations.Tests
{
    [TestClass]
    public class OperationT2Tests
    {
        [TestMethod]
        public void Invoke()
        {
            // This is one of the more spooky situations, where T1 and T2 unify.
            IOperationFunc<string, string, int> action =
                new OperationFunc<string, string, int>(
                    x => 1,
                    x => 2);

            string foo = "asdf";

            Assert.AreEqual(1, foo.Invoke(t1: action));
            Assert.AreEqual(2, foo.Invoke(t2: action));
        }
    }
}