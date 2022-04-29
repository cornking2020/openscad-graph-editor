using JetBrains.Annotations;
using OpenScadGraphEditor.Library;
using OpenScadGraphEditor.Utils;

namespace OpenScadGraphEditor.Nodes
{
    [UsedImplicitly]
    public class ConstructRange : ScadNode, IAmAnExpression
    {
        public override string NodeTitle => "Construct Range";
        public override string NodeDescription => "Constructs a range of integers.";


        public ConstructRange()
        {
            InputPorts
                .Number("Start")
                .Number("Step", defaultValue: 1)
                .Number("End");

            OutputPorts
                .Array();
        }

        public override string Render(IScadGraph context)
        {
            var start = RenderInput(context, 0).OrDefault("0");
            var step = RenderInput(context, 1).OrDefault("1");
            var end = RenderInput(context, 2).OrDefault("1");

            return $"[{start}:{step}:{end}]";
        }
    }
}