using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Operations.Generated.Tests
{
    [TestClass]
    public sealed class Generator_IOperationAsyncFuncTests
    {
        [TestMethod]
        public void Build()
        {
            const string expected =
@"// Auto-generated code
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
    /// <summary>
    /// Represents an asynchronous operation that returns a result.
    /// </summary>
    /// <typeparam name=""T1"">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name=""T2"">
    /// Supported type 2.
    /// </typeparam>
    /// <typeparam name=""TResult"">
    /// The type of returned result.
    /// </typeparam>
    public interface IOperationAsyncFunc<in T1, in T2, TResult>
    {
        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T1""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T1""/>.
        /// </param>
        /// <param name=""cancellationToken"">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref=""Task{TResult}""/> representing the invocation of this operation.
        /// </returns>
        Task<TResult> InvokeT1Async(T1 input, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T2""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T2""/>.
        /// </param>
        /// <param name=""cancellationToken"">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref=""Task{TResult}""/> representing the invocation of this operation.
        /// </returns>
        Task<TResult> InvokeT2Async(T2 input, CancellationToken cancellationToken);
    }
}";

            string actual = new Generator_IOperationAsyncFunc(2).Build();
            Assert.AreEqual(expected, actual);
        }
    }
}
