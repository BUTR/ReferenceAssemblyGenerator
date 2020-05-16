using System;
using System.IO;
using dnlib.DotNet;

namespace ReferenceAssemblyGenerator {

  public partial class AssemblyProcessor {

    public void Process(Options opts) {
      var source = opts.AssemblyPath;
      if (!File.Exists(source))
        throw new FileNotFoundException("Assembly file was not found", source);

      var destination = opts.OutputFile;
      if (string.IsNullOrEmpty(destination)) {
        var fileName = Path.GetFileNameWithoutExtension(source);
        var extension = Path.GetExtension(source);

        opts.OutputFile = destination = source!.Replace(fileName + extension, fileName + "-ref" + extension);
      }

      if (File.Exists(destination)) {
        if (FileSystemHelpers.PathEquals(source, destination))
          throw new Exception("Aborting because the output file appears to be the input file.");

        if (!opts.Force)
          throw new Exception("Output file exists already. Use --force to override it.");

        File.Delete(destination);
      }

      using var inputStream = File.OpenRead(source);
      using var outputStream = File.Open(destination, FileMode.CreateNew);
      var module = ModuleDefMD.Load(inputStream);

      ProcessMembers(module.Types);

      module.IsILOnly = true;
      module.VTableFixups = null;
      module.IsStrongNameSigned = false;
      module.Assembly.PublicKey = null;
      module.Assembly.HasPublicKey = false;

      ProcessManifestResources(module.Resources);
      ProcessWin32Resources(module.Win32Resources);
      ProcessAssemblyAttributes(module);

      module.Write(outputStream);
    }

  }

}