﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
    /// <summary>
    /// An asynchronous operation that returns a result.
    /// </summary>
    /// <typeparam name="T1">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name="T2">
    /// Supported type 2.
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type of returned result.
    /// </typeparam>
    public sealed class OperationAsyncFunc<T1, T2, TResult> : IOperationAsyncFunc<T1, T2, TResult>
    {
        private readonly Func<T1, CancellationToken, Task<TResult>> t1;
        private readonly Func<T2, CancellationToken, Task<TResult>> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationAsyncFunc{T1, T2, TResult}"/> class.
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
        public OperationAsyncFunc(
            Func<T1, CancellationToken, Task<TResult>> t1,
            Func<T2, CancellationToken, Task<TResult>> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        /// <inheritdoc/>
        public Task<TResult> InvokeT1Async(T1 input, CancellationToken cancellationToken) =>
            this.t1.Invoke(input, cancellationToken);

        /// <inheritdoc/>
        public Task<TResult> InvokeT2Async(T2 input, CancellationToken cancellationToken) =>
            this.t2.Invoke(input, cancellationToken);
    }
}
