using System.Linq;
using dnlib.DotNet;

namespace ReferenceAssemblyGenerator {

  public partial class AssemblyProcessor {

    private void ProcessProperties(TypeDef type) {
      var propertiesCopy = type.Properties.ToList();
      foreach (var property in propertiesCopy) {
        var getMethod = property.GetMethod;
        var setMethod = property.SetMethod;

        if (getMethod != null || setMethod != null) {
          if (getMethod != null)
            PurgeMethodBody(getMethod);

          if (setMethod != null)
            PurgeMethodBody(setMethod);
        }

        if (getMethod == null && setMethod == null)
          type.Properties.Remove(property);
      }
    }

  }

}