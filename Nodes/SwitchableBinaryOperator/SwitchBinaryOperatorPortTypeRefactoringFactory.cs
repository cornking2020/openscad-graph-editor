using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using OpenScadGraphEditor.Library;
using OpenScadGraphEditor.Refactorings;

namespace OpenScadGraphEditor.Nodes.SwitchableBinaryOperator
{
    [UsedImplicitly]
    public class SwitchBinaryOperatorPortTypeRefactoringFactory : IUserSelectableRefactoringFactory
    {
        public IEnumerable<UserSelectableNodeRefactoring> GetRefactorings(ScadGraph graph, ScadNode node)
        {
            return new[] {true, false}.SelectMany(
                i => new[] {PortType.Array, PortType.Any, PortType.Number, PortType.Vector3, PortType.Vector2, PortType.Boolean, PortType.String},
                (i, j) => new SwitchBinaryOperatorPortTypeRefactoring(graph, node, i, j));
        }
    }
}