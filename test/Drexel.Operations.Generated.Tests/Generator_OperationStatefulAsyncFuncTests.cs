using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Operations.Generated.Tests
{
    [TestClass]
    public sealed class Generator_OperationStatefulAsyncFuncTests
    {
        [TestMethod]
        public void Build()
        {
            const string expected =
@"// Auto-generated code
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
    /// <summary>
    /// An asynchronous operation that depends on external state and returns a result.
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
    /// <typeparam name=""TResult"">
    /// The type of returned result.
    /// </typeparam>
    public sealed class OperationStatefulAsyncFunc<T1, T2, TState, TResult> : IOperationStatefulAsyncFunc<T1, T2, TState, TResult>
    {
        private readonly Func<T1, TState, CancellationToken, Task<TResult>> t1;
        private readonly Func<T2, TState, CancellationToken, Task<TResult>> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref=""OperationStatefulAsyncFunc{T1, T2, TState, TResult}""/> class.
        /// </summary>
        /// <param name=""t1"">
        /// The delegate associated with <typeparamref name=""T1""/>.
        /// </param>
        /// <param name=""t2"">
        /// The delegate associated with <typeparamref name=""T2""/>.
        /// </param>
        /// <exception cref=""ArgumentNullException"">
        /// Thrown when any of the supplied delegates is <see langword=""null""/>.
        /// </exception>
        public OperationStatefulAsyncFunc(
            Func<T1, TState, CancellationToken, Task<TResult>> t1,
            Func<T2, TState, CancellationToken, Task<TResult>> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        public Task<TResult> InvokeT1Async(T1 input, TState state, CancellationToken cancellationToken) =>
            this.t1.Invoke(input, state, cancellationToken);

        public Task<TResult> InvokeT2Async(T2 input, TState state, CancellationToken cancellationToken) =>
            this.t2.Invoke(input, state, cancellationToken);
    }
}";

            string actual = new Generator_OperationStatefulAsyncFunc(2).Build();
            Assert.AreEqual(expected, actual);
        }
    }
}
