﻿using System;

namespace Drexel.Operations
{
    /// <summary>
    /// A synchronous operation that depends on external state and does not return a result.
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
    public sealed class OperationStatefulAction<T1, T2, TState> : IOperationStatefulAction<T1, T2, TState>
    {
        private readonly Action<T1, TState> t1;
        private readonly Action<T2, TState> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationStatefulAction{T1, T2, TState}"/> class.
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
        public OperationStatefulAction(
            Action<T1, TState> t1,
            Action<T2, TState> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        /// <inheritdoc/>
        public void InvokeT1(T1 input, TState state) => this.t1.Invoke(input, state);

        /// <inheritdoc/>
        public void InvokeT2(T2 input, TState state) => this.t2.Invoke(input, state);
    }
}
