using System;
using OpenScadGraphEditor.Nodes;
using OpenScadGraphEditor.Utils;

namespace OpenScadGraphEditor.Library
{
    public readonly struct FunctionBuilder
    {
        private readonly FunctionDescription _currentFunctionDescription;

        private FunctionBuilder(FunctionDescription currentFunctionDescription)
        {
            _currentFunctionDescription = currentFunctionDescription;
        }

        public static FunctionBuilder NewFunction(string name, string id = "", PortType returnType = PortType.Any)
        {
            var builder = new FunctionBuilder(Prefabs.New<FunctionDescription>())
            {
                _currentFunctionDescription =
                {
                    Name = name,
                    ReturnTypeHint = returnType,
                    Id = id.Length > 0 ? id : Guid.NewGuid().ToString()
                }
            };
            return builder;
        }

        public static FunctionBuilder NewBuiltInFunction(string name, string nodeName = "", PortType returnType = PortType.Any,  string idSuffix = "")
        {
            var builder = NewFunction(name, "__builtin__function__" + name + idSuffix, returnType);
            builder._currentFunctionDescription.IsBuiltin = true;
            builder._currentFunctionDescription.NodeName = nodeName;
            return builder;
        }

        public FunctionBuilder WithDescription(string description)
        {
            _currentFunctionDescription.Description = description;
            return this;
        }

        public FunctionBuilder WithParameter(string name, PortType typeHint = PortType.Any, bool isAutoCoerced = false,
            string label = "", string description = "")
        {
            var parameter = Prefabs.New<ParameterDescription>();
            parameter.Name = name;
            parameter.Description = description;
            parameter.TypeHint = typeHint;
            parameter.IsAutoCoerced = isAutoCoerced;
            parameter.Label = label;

            _currentFunctionDescription.Parameters.Add(parameter);
            return this;
        }

        public FunctionDescription Build()
        {
            return _currentFunctionDescription;
        }
    }
}