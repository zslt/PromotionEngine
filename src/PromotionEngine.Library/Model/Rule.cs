using System;

namespace PromotionEngine.Library.Model
{
    public class Rule
    {
        private readonly Operation operation;
        private readonly double value;

        public Rule(Operation operation, double value)
        {
            this.operation = operation;
            this.value = value;
        }

        internal double Apply(double amount, int applicatonNumber) => operation switch
        {
            Operation.Subtract => applicatonNumber * (amount - value),
            Operation.Multiply => applicatonNumber * (amount * value),
            _ => throw new InvalidOperationException()
        };
    }
}