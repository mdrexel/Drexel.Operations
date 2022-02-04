using System;

namespace Drexel.Operations
{
    /// <summary>
    /// A synchronous operation that depends on external state and returns a result.
    /// </summary>
    /// <typeparam name="T1">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name="T2">
    /// Supported type 2.
    /// </typeparam>
    /// <typeparam name="TState">
    /// The type of external state.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type of returned result.
    /// </typeparam>
    public sealed class OperationStatefulFunc<T1, T2, TState, TResult> : IOperationStatefulFunc<T1, T2, TState, TResult>
    {
        private readonly Func<T1, TState, TResult> t1;
        private readonly Func<T2, TState, TResult> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationStatefulFunc{T1, T2, TState, TResult}"/> class.
        /// </summary>
        /// <param name="t1">
        /// The delegate associated with <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t2">
        /// The delegate associated with <typeparamref name="T2"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when any of the supplied delegates is <see langword="null"/>.
        /// </exception>
        public OperationStatefulFunc(
            Func<T1, TState, TResult> t1,
            Func<T2, TState, TResult> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        public TResult InvokeT1(T1 input, TState state) => this.t1.Invoke(input, state);

        public TResult InvokeT2(T2 input, TState state) => this.t2.Invoke(input, state);
    }
}
