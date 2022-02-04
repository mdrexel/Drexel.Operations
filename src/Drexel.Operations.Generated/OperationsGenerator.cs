using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Drexel.Operations.Generated
{
    [Generator]
    public sealed class OperationsGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {


            // Add the source code to the compilation
            ////context.AddSource($"{typeName}.g.cs", source);
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
