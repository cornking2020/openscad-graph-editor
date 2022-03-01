using JetBrains.Annotations;

namespace OpenScadGraphEditor.Nodes
{
    [UsedImplicitly]
    public class AddOperator : BinaryNumericOperator
    {
        public override string NodeTitle => "+";
        public override string NodeDescription => "Adds the given inputs.";
        protected override string OperatorSign => "+";
    }
}