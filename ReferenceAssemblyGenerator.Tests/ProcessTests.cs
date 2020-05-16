using System;
using System.IO;
using NUnit.Framework;

namespace ReferenceAssemblyGenerator.Tests {

  public class ProcessTests {

    [Test]
    public void ProcessTestAssembly() {
      var processor = new AssemblyProcessor();

      var asmPath = typeof(ProcessTests).Assembly.CodeBase;
      var asmName = $"{Path.GetFileNameWithoutExtension(asmPath)}-ref{Path.GetExtension(asmPath)}";

      var output = Path.Combine(Environment.CurrentDirectory, asmName!);
      File.Delete(output);

      processor.Process(new Options {
        AssemblyPath = new Uri(asmPath!).LocalPath,
        OutputFile = output
      });
      
      Assert.True(File.Exists(output));
    }

    [Test]
    public void ProcessOwnAssembly() {
      var processor = new AssemblyProcessor();

      var asmPath = typeof(AssemblyProcessor).Assembly.CodeBase;
      var asmName = $"{Path.GetFileNameWithoutExtension(asmPath)}-ref{Path.GetExtension(asmPath)}";

      
      var output = Path.Combine(Environment.CurrentDirectory, asmName!);
      File.Delete(output);

      
      processor.Process(new Options {
        AssemblyPath = new Uri(asmPath!).LocalPath,
        OutputFile = output
      });
      
      Assert.True(File.Exists(output));
    }

    [Test]
    public void ProcessSystemAssembly() {
      var processor = new AssemblyProcessor();

      var asmPath = typeof(object).Assembly.CodeBase;
      var asmName = $"{Path.GetFileNameWithoutExtension(asmPath)}-ref{Path.GetExtension(asmPath)}";

      var output = Path.Combine(Environment.CurrentDirectory, asmName!);
      File.Delete(output);

      processor.Process(new Options {
        AssemblyPath = new Uri(asmPath!).LocalPath,
        OutputFile = output
      });
      
      Assert.True(File.Exists(output));
    }

  }

}