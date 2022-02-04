using System;

namespace Drexel.Operations.Generated
{
    public abstract class GeneratorBase
    {
        public GeneratorBase(uint order)
        {
            this.Order = order;
            if (this.Order < 1)
            {
                throw new ArgumentException("Order must be at least 1.");
            }
        }

        protected uint Order { get; }

        public string Build()
        {
            return "// Auto-generated code\r\n" + this.BuildInternal();
        }

        protected abstract string BuildInternal();

        protected void ForOrder(Action<int> callback, int startAt = 1)
        {
            for (int counter = startAt; counter < this.Order + 1; counter++)
            {
                callback.Invoke(counter);
            }
        }
    }
}
