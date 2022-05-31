using System.Linq;
using JetBrains.Annotations;
using OpenScadGraphEditor.Library;
using OpenScadGraphEditor.Refactorings;
using OpenScadGraphEditor.Utils;

namespace OpenScadGraphEditor.Nodes.ForLoop
{
    [UsedImplicitly]
    public class DecreaseLoopNestLevelRefactoring : UserSelectableNodeRefactoring
    {
        public override string Title => "Decrease Loop Nest Level";
        public override int Order => 1;
        public override bool IsApplicableToNode => Node is ForLoop forLoop && forLoop.NestLevel > 1;

        public DecreaseLoopNestLevelRefactoring(ScadGraph holder, ScadNode node) : base(holder, node)
        {
        }
        
        public override void PerformRefactoring(RefactoringContext context)
        {
            var node = (ForLoop) Node;

            // when decreasing nest level, we loose connections (incoming and outgoing)
            // incoming connections
            Holder.GetAllConnections()
                .Where(it => it.IsTo(node, node.NestLevel))
                .ToList() // make a new list, so we don't change the collection while iterating over it
                .ForAll(it => Holder.RemoveConnection(it));
            
            // outgoing connections
            Holder.GetAllConnections()
                .Where(it => it.IsFrom(node, node.NestLevel))
                .ToList() // make a new list, so we don't change the collection while iterating over it
                .ForAll(it => Holder.RemoveConnection(it));
            
            
            node.DecreaseNestLevel();
        }
    }
}