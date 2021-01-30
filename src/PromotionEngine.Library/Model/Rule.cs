using System;

namespace PromotionEngine.Library.Model
{
    public class Rule
    {
        private readonly Operation operation;
        private readonly decimal value;

        public Rule(Operation operation, decimal value)
        {
            this.operation = operation;
            this.value = value;
        }

        internal decimal Apply(decimal amount, int applicatonNumber) => operation switch
        {
            Operation.Subtract => applicatonNumber * (amount - value),
            Operation.Multiply => applicatonNumber * (amount * value),
            _ => throw new InvalidOperationException()
        };
    }
}