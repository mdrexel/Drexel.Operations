﻿using System.Text;

/*
using System;

namespace Drexel.Operations
{
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
}
*/

namespace Drexel.Operations.Generated
{
    public sealed class Generator_OperationStatefulAction : GeneratorBase
    {
        public Generator_OperationStatefulAction(uint order)
            : base(order)
        {
        }

        private string BuildGenerics(bool xmldoc = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(xmldoc ? '{' : '<');
            builder.Append("T1");

            this.ForOrder(x => builder.Append($", T{x}"), startAt: 2);

            builder.Append(", TState");
            builder.Append(xmldoc ? '}' : '>');

            return builder.ToString();
        }

        private string BuildClassName(bool xmldoc = false, bool generic = true)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("OperationStatefulAction");
            if (generic)
            {
                builder.Append(this.BuildGenerics(xmldoc));
            }

            return builder.ToString();
        }

        private string BuildInterfaceName(bool xmldoc = false)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("IOperationStatefulAction");
            builder.Append(this.BuildGenerics(xmldoc));

            return builder.ToString();
        }

        private string BuildDelegate(int order)
        {
            return $"Action<T{order}, TState>";
        }

        protected override string BuildInternal()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(
@"using System;

namespace Drexel.Operations
{
    /// <summary>
    /// A synchronous operation that depends on external state and does not return a result.
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
@"    /// <typeparam name=""TState"">
    /// The type of external state.
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
                    builder.AppendLine($"        public void InvokeT{x}(T{x} input, TState state) => this.t{x}.Invoke(input, state);");
                });

            builder.Append(
@"    }
}");

            return builder.ToString();
        }
    }
}
