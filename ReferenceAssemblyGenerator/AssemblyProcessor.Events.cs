using System.Linq;
using dnlib.DotNet;

namespace ReferenceAssemblyGenerator {

  public partial class AssemblyProcessor {

    private void ProcessEvents(TypeDef type) {
      var eventsCopy = type.Events.ToList();
      foreach (var @event in eventsCopy) {
        var addMethod = @event.AddMethod;
        var invokeMethod = @event.InvokeMethod;
        var removeMethod = @event.RemoveMethod;
        var otherMethods = @event.OtherMethods;

        if (addMethod != null)
          PurgeMethodBody(addMethod);

        if (invokeMethod != null)
          PurgeMethodBody(invokeMethod);

        if (removeMethod != null)
          PurgeMethodBody(removeMethod);

        if (otherMethods != null)
          foreach (var otherMethod in otherMethods.ToList())
            PurgeMethodBody(otherMethod);

        if (@event.OtherMethods.Count == 0)
          otherMethods = null;

        if (addMethod == null
          && invokeMethod == null
          && removeMethod == null
          && otherMethods == null)
          type.Events.Remove(@event);
      }
    }

  }

}