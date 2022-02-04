namespace Drexel.Operations
{
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
}
