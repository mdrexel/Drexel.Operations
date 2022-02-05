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
            const uint maximumOrderInclusive = 20;

            for (uint counter = 0; counter < maximumOrderInclusive; counter++)
            {
                uint order = counter + 1;

                context.AddSource($"IOperationAction.T{order}.g.cs", new Generator_IOperationAction(order).Build());
                context.AddSource($"IOperationAsyncAction.T{order}.g.cs", new Generator_IOperationAsyncAction(order).Build());
                context.AddSource($"IOperationAsyncFunc.T{order}.g.cs", new Generator_IOperationAsyncFunc(order).Build());
                context.AddSource($"IOperationFunc.T{order}.g.cs", new Generator_IOperationFunc(order).Build());
            }
        }
    }
}
