using System;
using OpenScadGraphEditor.Utils;

namespace OpenScadGraphEditor.Library.External
{
    public static class ExternalReferenceBuilder
    {
        public static ExternalReference Build(IncludeMode includeMode, string sourceFile, ExternalReference owner = null)
        {
            var reference = Prefabs.New<ExternalReference>();
            reference.Id = Guid.NewGuid().ToString();
            reference.Mode = includeMode;
            reference.IncludePath = sourceFile;
            reference.IncludedBy = owner?.Id ?? "";

            return reference;
        }
        public static ExternalReference BuildEmptyCopy(ExternalReference original)
        {
            var reference = Prefabs.New<ExternalReference>();
            reference.Id = Guid.NewGuid().ToString();
            reference.Mode = original.Mode;
            reference.IncludePath = original.IncludePath;
            reference.IncludedBy = original.IncludedBy;

            return reference;
        }
    }
}