using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Operations.Generated.Tests
{
    [TestClass]
    public sealed class Generator_IOperationStatefulAsyncActionTests
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
    /// Represents an asynchronous operation that depends on external state and does not return a result.
    /// </summary>
    /// <typeparam name=""T1"">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name=""T2"">
    /// Supported type 2.
    /// </typeparam>
    /// <typeparam name=""TState"">
    /// The type of external state.
    /// </typeparam>
    public interface IOperationStatefulAsyncAction<in T1, in T2, in TState>
    {
        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T1""/> using the supplied <paramref name=""state""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T1""/>.
        /// </param>
        /// <param name=""state"">
        /// The state.
        /// </param>
        /// <param name=""cancellationToken"">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref=""Task""/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT1Async(T1 input, TState state, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T2""/> using the supplied <paramref name=""state""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T2""/>.
        /// </param>
        /// <param name=""state"">
        /// The state.
        /// </param>
        /// <param name=""cancellationToken"">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref=""Task""/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT2Async(T2 input, TState state, CancellationToken cancellationToken);
    }
}";

            string actual = new Generator_IOperationStatefulAsyncAction(2).Build();
            Assert.AreEqual(expected, actual);
        }
    }
}
