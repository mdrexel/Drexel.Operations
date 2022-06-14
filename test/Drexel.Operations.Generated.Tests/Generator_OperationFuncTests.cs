using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drexel.Operations.Generated.Tests
{
    [TestClass]
    public sealed class Generator_OperationFuncTests
    {
        [TestMethod]
        public void Build()
        {
            const string expected =
@"// Auto-generated code
using System;

namespace Drexel.Operations
{
    /// <summary>
    /// A synchronous operation that returns a result.
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
    public sealed class OperationFunc<T1, T2, TResult> : IOperationFunc<T1, T2, TResult>
    {
        private readonly Func<T1, TResult> t1;
        private readonly Func<T2, TResult> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref=""OperationFunc{T1, T2, TResult}""/> class.
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
        public OperationFunc(
            Func<T1, TResult> t1,
            Func<T2, TResult> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        /// <inheritdoc/>
        public TResult InvokeT1(T1 input) => this.t1.Invoke(input);

        /// <inheritdoc/>
        public TResult InvokeT2(T2 input) => this.t2.Invoke(input);
    }
}";

            string actual = new Generator_OperationFunc(2).Build();
            Assert.AreEqual(expected, actual);
        }
    }
}
