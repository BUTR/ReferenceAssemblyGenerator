using dnlib.DotNet;
using dnlib.W32Resources;

namespace ReferenceAssemblyGenerator {

  public partial class AssemblyProcessor {

    private void ProcessWin32Resources(Win32Resources resources)
      => ProcessWin32Resources(resources.Root);

    private void ProcessWin32Resources(ResourceDirectory dir) {
      dir.Data.Clear();
      foreach (var subDir in dir.Directories)
        ProcessWin32Resources(subDir);
    }

    private void ProcessManifestResources(ResourceCollection resources)
      => resources.Clear();

  }

}