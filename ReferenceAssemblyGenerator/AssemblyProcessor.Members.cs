using System.Collections.Generic;
using dnlib.DotNet;

namespace ReferenceAssemblyGenerator {

  public partial class AssemblyProcessor {

    private void ProcessMembers(IEnumerable<TypeDef> types) {
      foreach (var type in types)
        ProcessMembers(type);
    }

    private void ProcessMembers(TypeDef type) {
      if (type.Namespace.StartsWith("JetBrains.Annotations"))
        type.Attributes |= TypeAttributes.NestedFamily;

      ProcessMethods(type);

      ProcessProperties(type);

      ProcessEvents(type);

      ProcessMembers(type.NestedTypes);
    }

  }

}