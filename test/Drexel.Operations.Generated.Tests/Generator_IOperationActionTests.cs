using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Operations.Generated.Tests
{
    [TestClass]
    public sealed class Generator_IOperationActionTests
    {
        [TestMethod]
        public void Build()
        {
            const string expected =
@"// Auto-generated code
namespace Drexel.Operations
{
    /// <summary>
    /// Represents a synchronous operation that does not return a result.
    /// </summary>
    /// <typeparam name=""T1"">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name=""T2"">
    /// Supported type 2.
    /// </typeparam>
    public interface IOperationAction<in T1, in T2>
    {
        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T1""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T1""/>.
        /// </param>
        void InvokeT1(T1 input);

        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T2""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T2""/>.
        /// </param>
        void InvokeT2(T2 input);
    }
}";

            Assert.AreEqual(expected, new Generator_IOperationAction(2).Build());
        }
    }
}
