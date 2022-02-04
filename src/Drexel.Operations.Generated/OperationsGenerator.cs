using System;
using System.Collections.Generic;
using System.Text;
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
            const uint maximumOrderIncluxive = 20;

            for (uint counter = 0; counter < maximumOrderIncluxive; counter++)
            {
                uint order = counter + 1;

                context.AddSource($"IOperationAction.T{order}.g.cs", new Generator_IOperationAction(order).Build());
            }
        }
    }
}
