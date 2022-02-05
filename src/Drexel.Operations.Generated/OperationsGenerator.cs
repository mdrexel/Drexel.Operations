using Microsoft.CodeAnalysis;

namespace Drexel.Operations.Generated
{
    [Generator]
    public sealed class OperationsGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            const uint maximumOrderInclusive = 50;

            for (uint counter = 0; counter < maximumOrderInclusive; counter++)
            {
                uint order = counter + 1;

                context.AddSource($"IOperationAction.T{order}.g.cs", new Generator_IOperationAction(order).Build());
                context.AddSource($"IOperationAsyncAction.T{order}.g.cs", new Generator_IOperationAsyncAction(order).Build());
                context.AddSource($"IOperationAsyncFunc.T{order}.g.cs", new Generator_IOperationAsyncFunc(order).Build());
                context.AddSource($"IOperationFunc.T{order}.g.cs", new Generator_IOperationFunc(order).Build());
                context.AddSource($"IOperationStatefulAction.T{order}.g.cs", new Generator_IOperationStatefulAction(order).Build());
                context.AddSource($"IOperationStatefulAsyncAction.T{order}.g.cs", new Generator_IOperationStatefulAsyncAction(order).Build());
                context.AddSource($"IOperationStatefulAsyncFunc.T{order}.g.cs", new Generator_IOperationStatefulAsyncFunc(order).Build());
                context.AddSource($"IOperationStatefulFunc.T{order}.g.cs", new Generator_IOperationStatefulFunc(order).Build());

                context.AddSource($"OperationAction.T{order}.g.cs", new Generator_OperationAction(order).Build());
                context.AddSource($"OperationAsyncAction.T{order}.g.cs", new Generator_OperationAsyncAction(order).Build());
                context.AddSource($"OperationAsyncFunc.T{order}.g.cs", new Generator_OperationAsyncFunc(order).Build());
                context.AddSource($"OperationFunc.T{order}.g.cs", new Generator_OperationFunc(order).Build());
                context.AddSource($"OperationStatefulAction.T{order}.g.cs", new Generator_OperationStatefulAction(order).Build());
                context.AddSource($"OperationStatefulAsyncAction.T{order}.g.cs", new Generator_OperationStatefulAsyncAction(order).Build());
                context.AddSource($"OperationStatefulAsyncFunc.T{order}.g.cs", new Generator_OperationStatefulAsyncFunc(order).Build());
                context.AddSource($"OperationStatefulFunc.T{order}.g.cs", new Generator_OperationStatefulFunc(order).Build());
            }
        }
    }
}
