using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using dnlib.DotNet;

namespace ReferenceAssemblyGenerator {

  public partial class AssemblyProcessor {

    private static void ProcessAssemblyAttributes(ModuleDefMD module) {
      var importer = new Importer(module);
      var method = importer.Import(RefAsmAttribCtor);

      var asmAttribsCopy = module.Assembly.CustomAttributes.ToList();

      foreach (var attrib in asmAttribsCopy) {
        switch (attrib.TypeFullName) {
          case "System.Reflection.AssemblyVersionAttribute":
          case "System.Reflection.AssemblyFileVersionAttribute":
          case "System.Reflection.AssemblyInformationalVersionAttribute":
          case "System.Runtime.Versioning.TargetFrameworkAttribute":
          case "System.Runtime.InteropServices.GuidAttribute":
            continue;

          default:
            module.Assembly.CustomAttributes.Remove(attrib);
            break;
        }
      }

      module.Assembly.CustomAttributes
        .Add(new CustomAttribute((IMethodDefOrRef) method));
    }

    private static readonly ConstructorInfo RefAsmAttribCtor = typeof(ReferenceAssemblyAttribute).GetConstructor(Type.EmptyTypes);

  }

}