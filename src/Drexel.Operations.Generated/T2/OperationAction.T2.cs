using System;

namespace Drexel.Operations
{
    /// <summary>
    /// A synchronous operation that does not return a result.
    /// </summary>
    /// <typeparam name="T1">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name="T2">
    /// Supported type 2.
    /// </typeparam>
    public sealed class OperationAction<T1, T2> : IOperationAction<T1, T2>
    {
        private readonly Action<T1> t1;
        private readonly Action<T2> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationAction{T1, T2}"/> class.
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
        public OperationAction(
            Action<T1> t1,
            Action<T2> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        /// <inheritdoc/>
        public void InvokeT1(T1 input) => this.t1.Invoke(input);

        /// <inheritdoc/>
        public void InvokeT2(T2 input) => this.t2.Invoke(input);
    }
}
