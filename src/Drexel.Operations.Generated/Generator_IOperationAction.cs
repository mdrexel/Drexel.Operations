using System;
using System.Text;

/*
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
}
*/

namespace Drexel.Operations.Generated
{
    public sealed class Generator_IOperationAction
    {
        private readonly uint order;

        public Generator_IOperationAction(uint order)
        {
            this.order = order;
            if (this.order < 1)
            {
                throw new ArgumentException("Order must be at least 1.");
            }
        }

        public string Build()
        {
            if (this.order < 1)
            {
                throw new ArgumentException("Order must be at least 1.", nameof(this.order));
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(
@"// Auto-generated code
namespace Drexel.Operations
{
    /// <summary>
    /// Represents a synchronous operation that does not return a result.
    /// </summary>");

            for (uint counter = 1; counter < this.order + 1; counter++)
            {
                builder.AppendLine(
@$"    /// <typeparam name=""T{counter}"">
    /// Supported type {counter}.
    /// </typeparam>");
            }

            builder.Append("    public interface IOperationAction<in T1");
            for (uint counter = 2; counter < this.order + 1; counter++)
            {
                builder.Append(", in T");
                builder.Append(counter);
            }

            builder.AppendLine(">");
            builder.Append("    {");

            for (uint counter = 1; counter < this.order + 1; counter++)
            {
                builder.AppendLine();
                builder.Append(
$@"        /// <summary>
        /// Synchronously invokes this operation on the supplied <paramref name=""input""/> as an instance of
        /// <typeparamref name=""T{counter}""/>.
        /// </summary>
        /// <param name=""input"">
        /// The input as an instance of <typeparamref name=""T{counter}""/>.
        /// </param>
        void InvokeT{counter}(T{counter} input);
");
            }

            builder.Append(
@"    }
}");

            return builder.ToString();
        }
    }
}
