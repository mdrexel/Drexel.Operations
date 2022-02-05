using System.Text;

/*
using System;
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

        public Task<TResult> InvokeT1Async(T1 input, CancellationToken cancellationToken) =>
            this.t1.Invoke(input, cancellationToken);

        public Task<TResult> InvokeT2Async(T2 input, CancellationToken cancellationToken) =>
            this.t2.Invoke(input, cancellationToken);
    }
}
*/

namespace Drexel.Operations.Generated
{
    public sealed class Generator_OperationAsyncFunc : GeneratorBase
    {
        public Generator_OperationAsyncFunc(uint order)
            : base(order)
        {
        }

        private string BuildGenerics(bool xmldoc = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(xmldoc ? '{' : '<');
            builder.Append("T1");

            this.ForOrder(x => builder.Append($", T{x}"), startAt: 2);

            builder.Append(", TResult");

            builder.Append(xmldoc ? '}' : '>');

            return builder.ToString();
        }

        private string BuildClassName(bool xmldoc = false, bool generic = true)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("OperationAsyncFunc");
            if (generic)
            {
                builder.Append(this.BuildGenerics(xmldoc));
            }

            return builder.ToString();
        }

        private string BuildInterfaceName(bool xmldoc = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("IOperationAsyncFunc");
            builder.Append(this.BuildGenerics(xmldoc));

            return builder.ToString();
        }

        private string BuildDelegate(int order)
        {
            return $"Func<T{order}, CancellationToken, Task<TResult>>";
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
    /// An asynchronous operation that returns a result.
    /// </summary>");

            this.ForOrder(
                x =>
                {
                    builder.AppendLine(
@$"    /// <typeparam name=""T{x}"">
    /// Supported type {x}.
    /// </typeparam>");
                });

            builder.AppendLine(
@"    /// <typeparam name=""TResult"">
    /// The type of returned result.
    /// </typeparam>");

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
                    builder.AppendLine($"        public Task<TResult> InvokeT{x}Async(T{x} input, CancellationToken cancellationToken) =>");
                    builder.AppendLine($"            this.t{x}.Invoke(input, cancellationToken);");
                });

            builder.Append(
@"    }
}");

            return builder.ToString();
        }
    }
}
