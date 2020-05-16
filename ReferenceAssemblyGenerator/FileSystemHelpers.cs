using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ReferenceAssemblyGenerator {

  internal static class FileSystemHelpers {

    internal static bool IsOsCaseSensitiveDefault
      => !RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        && !RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    internal static bool PathEquals(string source, string destination)
      => String.Equals(
        Path.GetFullPath(new Uri(source).LocalPath),
        Path.GetFullPath(new Uri(destination).LocalPath), IsOsCaseSensitiveDefault ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);

  }

}