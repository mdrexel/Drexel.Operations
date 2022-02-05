using System;
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
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
