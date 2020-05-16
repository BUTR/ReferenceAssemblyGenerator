using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ReferenceAssemblyGenerator {

  public partial class AssemblyProcessor {

    private static readonly Instruction[] ThrowingInstructionList = {
      Instruction.Create(OpCodes.Ldnull),
      Instruction.Create(OpCodes.Throw)
    };

    private static readonly CilBody ThrowingCilBody = CreateThrowingCilBody();

    private void ProcessMethods(TypeDef type) {
      foreach (var method in type.Methods.ToList())
        PurgeMethodBody(method);
    }

    private static CilBody CreateThrowingCilBody() {
      var body = new CilBody(false,
        ThrowingInstructionList,
        Array.Empty<ExceptionHandler>(),
        Array.Empty<Local>()
      );
      body.UpdateInstructionOffsets();
      return body;
    }

    private void PurgeMethodBody(MethodDef method) {
      if (!method.IsIL || method.Body == null) {
        return;
      }

      method.Body = ThrowingCilBody;
    }

  }

}