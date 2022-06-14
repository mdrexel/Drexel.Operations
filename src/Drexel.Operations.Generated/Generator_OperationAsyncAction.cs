using System.Text;

/*
using System;
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

        /// <inheritdoc/>
        public Task InvokeT1Async(T1 input, CancellationToken cancellationToken) =>
            this.t1.Invoke(input, cancellationToken);

        /// <inheritdoc/>
        public Task InvokeT2Async(T2 input, CancellationToken cancellationToken) =>
            this.t2.Invoke(input, cancellationToken);
    }
}

*/

namespace Drexel.Operations.Generated
{
    public sealed class Generator_OperationAsyncAction : GeneratorBase
    {
        public Generator_OperationAsyncAction(uint order)
            : base(order)
        {
        }

        private string BuildGenerics(bool xmldoc = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(xmldoc ? '{' : '<');
            builder.Append("T1");

            this.ForOrder(x => builder.Append($", T{x}"), startAt: 2);

            builder.Append(xmldoc ? '}' : '>');

            return builder.ToString();
        }

        private string BuildClassName(bool xmldoc = false, bool generic = true)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("OperationAsyncAction");
            if (generic)
            {
                builder.Append(this.BuildGenerics(xmldoc));
            }

            return builder.ToString();
        }

        private string BuildInterfaceName(bool xmldoc = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("IOperationAsyncAction");
            builder.Append(this.BuildGenerics(xmldoc));

            return builder.ToString();
        }

        private string BuildDelegate(int order)
        {
            return $"Func<T{order}, CancellationToken, Task>";
        }

        protected override string BuildInternal()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(
@"using System;
using System.Threading;
using System.Threading.Tasks;

namespace Drexel.Operations
{
    /// <summary>
    /// An asynchronous operation that does not return a result.
    /// </summary>");

            this.ForOrder(
                x =>
                {
                    builder.AppendLine(
@$"    /// <typeparam name=""T{x}"">
    /// Supported type {x}.
    /// </typeparam>");
                });

            builder.Append("    public sealed class ");
            builder.Append(this.BuildClassName());
            builder.Append(" : ");
            builder.AppendLine(this.BuildInterfaceName());
            builder.AppendLine("    {");

            // Fields
            this.ForOrder(x => builder.AppendLine(
@$"        private readonly {this.BuildDelegate(x)} t{x};"));

            // Constructor
            builder.AppendLine();
            builder.AppendLine(
@$"        /// <summary>
        /// Initializes a new instance of the <see cref=""{BuildClassName(true)}""/> class.
        /// </summary>");

            this.ForOrder(x => builder.AppendLine(
@$"        /// <param name=""t{x}"">
        /// The delegate associated with <typeparamref name=""T{x}""/>.
        /// </param>"));

            builder.AppendLine(
@"        /// <exception cref=""ArgumentNullException"">
        /// Thrown when any of the supplied delegates is <see langword=""null""/>.
        /// </exception>");

            builder.Append("        public ");
            builder.Append(this.BuildClassName(generic: false));
            builder.AppendLine("(");

            builder.Append($"            {this.BuildDelegate(1)} t1");
            this.ForOrder(
                startAt: 2,
                callback: x =>
                {
                    builder.AppendLine(",");
                    builder.Append("            ");
                    builder.Append(this.BuildDelegate(x));
                    builder.Append(" t");
                    builder.Append(x);
                });

            builder.AppendLine(")");
            builder.AppendLine("        {");

            this.ForOrder(x => builder.AppendLine($"            this.t{x} = t{x} ?? throw new ArgumentNullException(nameof(t{x}));"));

            builder.AppendLine("        }");

            // Methods
            this.ForOrder(
                x =>
                {
                    builder.AppendLine();
                    builder.AppendLine("        /// <inheritdoc/>");
                    builder.AppendLine($"        public Task InvokeT{x}Async(T{x} input, CancellationToken cancellationToken) =>");
                    builder.AppendLine($"            this.t{x}.Invoke(input, cancellationToken);");
                });

            builder.Append(
@"    }
}");

            return builder.ToString();
        }
    }
}
