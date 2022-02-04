using System;
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
    /// <summary>
    /// Represents a synchronous operation that does not return a result.
    /// </summary>
    /// <typeparam name="T1">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name="T2">
    /// Supported type 2.
    /// </typeparam>
    public interface IOperationAction<in T1, in T2>
    {
        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        void InvokeT1(T1 input);

        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T2"/>.
        /// </param>
        void InvokeT2(T2 input);
    }

    /// <summary>
    /// A synchronous operation that does not return a result.
    /// </summary>
    /// <typeparam name="T1">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name="T2">
    /// Supported type 1.
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

        public void InvokeT1(T1 input) => this.t1.Invoke(input);

        public void InvokeT2(T2 input) => this.t2.Invoke(input);
    }

    /// <summary>
    /// Represents a synchronous operation that depends on external state and does not return a result.
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
    public interface IOperationStatefulAction<in T1, in T2, in TState>
    {
        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/> using the supplied <paramref name="state"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        void InvokeT1(T1 input, TState state);

        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T2"/> using the supplied <paramref name="state"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        void InvokeT2(T2 input, TState state);
    }

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

        public void InvokeT1(T1 input, TState state) => this.t1.Invoke(input, state);

        public void InvokeT2(T2 input, TState state) => this.t2.Invoke(input, state);
    }

    /// <summary>
    /// Represents an asynchronous operation that does not return a result.
    /// </summary>
    /// <typeparam name="T1">
    /// Supported type 1.
    /// </typeparam>
    /// <typeparam name="T2">
    /// Supported type 2.
    /// </typeparam>
    public interface IOperationAsyncAction<in T1, in T2>
    {
        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT1Async(T1 input, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT2Async(T2 input, CancellationToken cancellationToken);
    }

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

    /// <summary>
    /// Represents an asynchronous operation that depends on external state and does not return a result.
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
    public interface IOperationStatefulAsyncAction<in T1, in T2, in TState>
    {
        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/> using the supplied <paramref name="state"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT1Async(T1 input, TState state, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously invokes this action on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T2"/> using the supplied <paramref name="state"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT2Async(T2 input, TState state, CancellationToken cancellationToken);
    }

    /// <summary>
    /// An asynchronous operation that depends on external state and does not return a result.
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
    public sealed class OperationStatefulAsyncAction<T1, T2, TState> : IOperationStatefulAsyncAction<T1, T2, TState>
    {
        private readonly Func<T1, TState, CancellationToken, Task> t1;
        private readonly Func<T2, TState, CancellationToken, Task> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationStatefulAsyncAction{T1, T2, TState}"/> class.
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
        public OperationStatefulAsyncAction(
            Func<T1, TState, CancellationToken, Task> t1,
            Func<T2, TState, CancellationToken, Task> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        public Task InvokeT1Async(T1 input, TState state, CancellationToken cancellationToken) =>
            this.t1.Invoke(input, state, cancellationToken);

        public Task InvokeT2Async(T2 input, TState state, CancellationToken cancellationToken) =>
            this.t2.Invoke(input, state, cancellationToken);
    }

    /// <summary>
    /// Represents a synchronous operation that returns a result.
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
    public interface IOperationFunc<in T1, in T2, out TResult>
    {
        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        TResult InvokeT1(T1 input);

        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T2"/>.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        TResult InvokeT2(T2 input);
    }

    /// <summary>
    /// A synchronous operation that returns a result.
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
    public sealed class OperationFunc<T1, T2, TResult> : IOperationFunc<T1, T2, TResult>
    {
        private readonly Func<T1, TResult> t1;
        private readonly Func<T2, TResult> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationFunc{T1, T2, TResult}"/> class.
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
        public OperationFunc(
            Func<T1, TResult> t1,
            Func<T2, TResult> t2)
        {
            this.t1 = t1 ?? throw new ArgumentNullException(nameof(t1));
            this.t2 = t2 ?? throw new ArgumentNullException(nameof(t2));
        }

        public TResult InvokeT1(T1 input) => this.t1.Invoke(input);

        public TResult InvokeT2(T2 input) => this.t2.Invoke(input);
    }

    /// <summary>
    /// Represents a synchronous operation that depends on external state and returns a result.
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
    public interface IOperationStatefulFunc<in T1, in T2, in TState, out TResult>
    {
        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        TResult InvokeT1(T1 input, TState state);

        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        TResult InvokeT2(T2 input, TState state);
    }

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

    /// <summary>
    /// Represents an asynchronous operation that returns a result.
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
    public interface IOperationAsyncFunc<in T1, in T2, TResult>
    {
        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of this operation.
        /// </returns>
        Task<TResult> InvokeT1Async(T1 input, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of this operation.
        /// </returns>
        Task<TResult> InvokeT2Async(T2 input, CancellationToken cancellationToken);
    }

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

        public Task<TResult> InvokeT1Async(T1 input, CancellationToken cancellationToken) =>
            this.t1.Invoke(input, cancellationToken);

        public Task<TResult> InvokeT2Async(T2 input, CancellationToken cancellationToken) =>
            this.t2.Invoke(input, cancellationToken);
    }

    /// <summary>
    /// Represents an asynchronous operation that depends on external state and returns a result.
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
    public interface IOperationStatefulAsyncFunc<in T1, in T2, in TState, TResult>
    {
        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of this operation.
        /// </returns>
        Task<TResult> InvokeT1Async(T1 input, TState state, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <param name="input">
        /// The input as an instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of this operation.
        /// </returns>
        Task<TResult> InvokeT2Async(T2 input, TState state, CancellationToken cancellationToken);
    }

    /// <summary>
    /// An asynchronous operation that depends on external state and returns a result.
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
    public sealed class OperationStatefulAsyncFunc<T1, T2, TState, TResult> : IOperationStatefulAsyncFunc<T1, T2, TState, TResult>
    {
        private readonly Func<T1, TState, CancellationToken, Task<TResult>> t1;
        private readonly Func<T2, TState, CancellationToken, Task<TResult>> t2;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationStatefulAsyncFunc{T1, T2, TState, TResult}"/> class.
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

    /// <summary>
    /// Defines operation extension methods.
    /// </summary>
    public static class OperationExtensions
    {
        /// <summary>
        /// Synchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static void Invoke<T1, T2>(this T1 in1, IOperationAction<T1, T2> t1)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            t1.InvokeT1(in1);
        }

        /// <summary>
        /// Synchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static void Invoke<T1, T2>(this T2 in2, IOperationAction<T1, T2> t2)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            t2.InvokeT2(in2);
        }

        /// <summary>
        /// Synchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static void Invoke<T1, T2, TState>(this T1 in1, IOperationStatefulAction<T1, T2, TState> t1, TState state)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            t1.InvokeT1(in1, state);
        }

        /// <summary>
        /// Synchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static void Invoke<T1, T2, TState>(this T2 in2, IOperationStatefulAction<T1, T2, TState> t2, TState state)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            t2.InvokeT2(in2, state);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t1"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of <paramref name="t1"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static Task InvokeAsync<T1, T2>(this T1 in1, IOperationAsyncAction<T1, T2> t1, CancellationToken cancellationToken)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            return t1.InvokeT1Async(in1, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t2"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of <paramref name="t2"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static Task InvokeAsync<T1, T2>(this T2 in2, IOperationAsyncAction<T1, T2> t2, CancellationToken cancellationToken)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            return t2.InvokeT2Async(in2, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t1"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of <paramref name="t1"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static Task InvokeAsync<T1, T2, TState>(this T1 in1, IOperationStatefulAsyncAction<T1, T2, TState> t1, TState state, CancellationToken cancellationToken)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            return t1.InvokeT1Async(in1, state, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t2"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the invocation of <paramref name="t2"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static Task InvokeAsync<T1, T2, TState>(this T2 in2, IOperationStatefulAsyncAction<T1, T2, TState> t2, TState state, CancellationToken cancellationToken)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            return t2.InvokeT2Async(in2, state, cancellationToken);
        }

        /// <summary>
        /// Synchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static TResult Invoke<T1, T2, TResult>(this T1 in1, IOperationFunc<T1, T2, TResult> t1)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            return t1.InvokeT1(in1);
        }

        /// <summary>
        /// Synchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static TResult Invoke<T1, T2, TResult>(this T2 in2, IOperationFunc<T1, T2, TResult> t2)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            return t2.InvokeT2(in2);
        }

        /// <summary>
        /// Synchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static TResult Invoke<T1, T2, TState, TResult>(this T1 in1, IOperationStatefulFunc<T1, T2, TState, TResult> t1, TState state)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            return t1.InvokeT1(in1, state);
        }

        /// <summary>
        /// Synchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static TResult Invoke<T1, T2, TState, TResult>(this T2 in2, IOperationStatefulFunc<T1, T2, TState, TResult> t2, TState state)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            return t2.InvokeT2(in2, state);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t1"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of <paramref name="t1"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static Task<TResult> InvokeAsync<T1, T2, TResult>(this T1 in1, IOperationAsyncFunc<T1, T2, TResult> t1, CancellationToken cancellationToken)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            return t1.InvokeT1Async(in1, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t2"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of <paramref name="t2"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static Task<TResult> InvokeAsync<T1, T2, TResult>(this T2 in2, IOperationAsyncFunc<T1, T2, TResult> t2, CancellationToken cancellationToken)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            return t2.InvokeT2Async(in2, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t1"/> using <paramref name="in1"/> as an instance of
        /// <typeparamref name="T1"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in1">
        /// The instance of <typeparamref name="T1"/>.
        /// </param>
        /// <param name="t1">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t1"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of <paramref name="t1"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t1"/> is <see langword="null"/>.
        /// </exception>
        public static Task<TResult> InvokeAsync<T1, T2, TState, TResult>(this T1 in1, IOperationStatefulAsyncFunc<T1, T2, TState, TResult> t1, TState state, CancellationToken cancellationToken)
        {
            if (t1 is null)
            {
                throw new ArgumentNullException(nameof(t1));
            }

            return t1.InvokeT1Async(in1, state, cancellationToken);
        }

        /// <summary>
        /// Asynchronously invokes the specified <paramref name="t2"/> using <paramref name="in2"/> as an instance of
        /// <typeparamref name="T2"/> and using the supplied <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="T1">
        /// Supported type 1.
        /// </typeparam>
        /// <typeparam name="T2">
        /// Supported type 2.
        /// </typeparam>
        /// <param name="in2">
        /// The instance of <typeparamref name="T2"/>.
        /// </param>
        /// <param name="t2">
        /// The operation to invoke.
        /// </param>
        /// <param name="state">
        /// The external state.
        /// </param>
        /// <param name="cancellationToken">
        /// Controls the lifetime of the invocation of <paramref name="t2"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the invocation of <paramref name="t2"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="t2"/> is <see langword="null"/>.
        /// </exception>
        public static Task<TResult> InvokeAsync<T1, T2, TState, TResult>(this T2 in2, IOperationStatefulAsyncFunc<T1, T2, TState, TResult> t2, TState state, CancellationToken cancellationToken)
        {
            if (t2 is null)
            {
                throw new ArgumentNullException(nameof(t2));
            }

            return t2.InvokeT2Async(in2, state, cancellationToken);
        }
    }
}
