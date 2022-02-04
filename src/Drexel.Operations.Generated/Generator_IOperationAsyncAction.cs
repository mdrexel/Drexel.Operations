using System.Text;

/*
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
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
}
*/

namespace Drexel.Operations.Generated
{
    public sealed class Generator_IOperationAsyncAction : GeneratorBase
    {
        public Generator_IOperationAsyncAction(uint order)
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
    /// Represents an asynchronous operation that does not return a result.
    /// </summary>");

            this.ForOrder(x => builder.AppendLine(
$@"    /// <typeparam name=""T{x}"">
    /// Supported type {x}.
    /// </typeparam>"));

            builder.Append("    public interface IOperationAsyncAction<in T1");
            this.ForOrder(
                startAt: 2,
                callback: x =>
                {
                    builder.Append(", in T");
                    builder.Append(x);
                });

            builder.AppendLine(">");
            builder.Append("    {");

            this.ForOrder(
                x =>
                {
                    builder.AppendLine();
                    builder.Append(
$@"        /// <summary>
        /// Asynchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T{x}""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T{x}""/>.
        /// </param>
        /// <param name=""cancellationToken"">
        /// Controls the lifetime of the invocation of this operation.
        /// </param>
        /// <returns>
        /// A <see cref=""Task""/> representing the invocation of this operation.
        /// </returns>
        Task InvokeT{x}Async(T{x} input, CancellationToken cancellationToken);
");
                });

            builder.Append(
@"    }
}");
            return builder.ToString();
        }
    }
}
