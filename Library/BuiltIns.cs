using System.Collections.Generic;
using OpenScadGraphEditor.Nodes;

namespace OpenScadGraphEditor.Library
{
    /// <summary>
    /// This class contains all built-in modules an functions.
    /// </summary>
    public static class BuiltIns
    {
        public static IReadOnlyCollection<ModuleDescription> Modules { get; }
        public static IReadOnlyCollection<FunctionDescription> Functions { get; }

        static BuiltIns()
        {
            Modules = new List<ModuleDescription>()
            {
                ModuleBuilder.NewBuiltInModule("cube", "Cube")
                    .WithDescription("Creates a cube in the first octant.\nWhen center is true, the cube is\ncentered on the origin.")
                    .WithParameter("size", PortType.Vector3, label: "Size")
                    .WithParameter("center", PortType.Boolean, label: "Center")
                    .Build(),
                ModuleBuilder.NewBuiltInModule("translate", "Translate")
                    .WithDescription("Translates (moves) its child\nelements along the specified offset.")
                    .WithParameter("v", PortType.Vector3, label: "Offset")
                    .WithChildren()
                    .Build(),
                ModuleBuilder.NewBuiltInModule("rotate", "Rotate (Axis/Angle)")
                    .WithDescription("Rotates the next elements\nalong the given axis and angle.")
                    .WithParameter("v", PortType.Vector3, label: "Axis")
                    .WithParameter("a", PortType.Number, label: "Angle")
                    .WithChildren()
                    .Build(),
                ModuleBuilder.NewBuiltInModule("rotate", "Rotate (Euler Angles)")
                    .WithDescription("Rotates the next elements\nalong the given Euler angles.")
                    .WithParameter("a", PortType.Vector3, label: "Euler Angles")
                    .WithChildren()
                    .Build(),
            };
            
            Functions = new List<FunctionDescription>()
            {
              FunctionBuilder.NewBuiltInFunction("abs", "Abs", PortType.Number)
                  .WithParameter("", PortType.Number)
                  .Build()
            };
        }
    }
}