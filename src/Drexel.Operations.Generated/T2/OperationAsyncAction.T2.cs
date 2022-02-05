﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
    /// <summary>
    /// An asynchronous operation that does not return a result.
    /// </summary>
    /// <typeparam name="T1">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name="T2">
    /// Supported type 2.
    /// </typeparam>
    public sealed class OperationAsyncAction<T1, T2> : IOperationAsyncAction<T1, T2>
    {
        private readonly Func<T1, CancellationToken, Task> t1;
        private readonly Func<T2, CancellationToken, Task> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationAsyncAction{T1, T2}"/> class.
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
        public OperationAsyncAction(
            Func<T1, CancellationToken, Task> t1,
            Func<T2, CancellationToken, Task> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        public Task InvokeT1Async(T1 input, CancellationToken cancellationToken) =>
            this.t1.Invoke(input, cancellationToken);

        public Task InvokeT2Async(T2 input, CancellationToken cancellationToken) =>
            this.t2.Invoke(input, cancellationToken);
    }
}
