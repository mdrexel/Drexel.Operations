using System.Text;

/*
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
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
        /// Asynchronously invokes this operation on the supplied <paramref name="input"/> as an instance of
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
}
*/

namespace Drexel.Operations.Generated
{
    public sealed class Generator_IOperationStatefulAsyncAction : GeneratorBase
    {
        public Generator_IOperationStatefulAsyncAction(uint order)
            : base(order)
        {
        }

        protected override string BuildInternal()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(
@"using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
    /// <summary>
    /// Represents an asynchronous operation that depends on external state and does not return a result.
    /// </summary>");

            this.ForOrder(x => builder.AppendLine(
$@"    /// <typeparam name=""T{x}"">
    /// Supported type {x}.
    /// </typeparam>"));

            builder.AppendLine(
@"    /// <typeparam name=""TState"">
    /// The type of external state.
    /// </typeparam>");

            builder.Append("    public interface IOperationStatefulAsyncAction<in T1");

            this.ForOrder(
                startAt: 2,
                callback: x =>
                {
                    builder.Append(", in T");
                    builder.Append(x);
                });

            builder.AppendLine(", in TState>");
            builder.Append("    {");


            this.ForOrder(
                x =>
                {
                    builder.AppendLine();
                    builder.Append(
$@"        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T{x}""/> using the supplied <paramref name=""state""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T{x}""/>.
        /// </param>
        /// <param name=""state"">
        /// The state.
        /// </param>
        /// <param name=""cancellationToken"">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref=""Task""/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT{x}Async(T{x} input, TState state, CancellationToken cancellationToken);
");
                });

            builder.Append(
@"    }
}");
            return builder.ToString();
        }
    }
}
