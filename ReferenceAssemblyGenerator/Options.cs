using CommandLine;
using JetBrains.Annotations;

namespace ReferenceAssemblyGenerator {

  [PublicAPI]
  public class Options {

    [Value(0, MetaName = "assemblyPath", Required = true, HelpText = "Path to assembly to generate reference assembly for.")]
    public string AssemblyPath { get; set; }

    [Option('o', "output", Required = false, HelpText = "Sets the output file")]
    public string OutputFile { get; set; }

    [Option('f', "force", Required = false, HelpText = "Overrides output file if it exists")]
    public bool Force { get; set; }

  }

}