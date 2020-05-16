using CommandLine;

namespace ReferenceAssemblyGenerator {

  public static class Program {

    public static int Main(string[] args) {
      var refAsmGen = new AssemblyProcessor();

      var result = Parser.Default
        .ParseArguments<Options>(args)
        .WithParsed(refAsmGen.Process);

      return result.Tag == ParserResultType.Parsed ? 0 : 1;
    }

  }

}