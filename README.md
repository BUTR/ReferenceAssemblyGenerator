# ReferenceAssemblyGenerator
A dotnet tool to generate reference assemblies.

### What is a reference assembly?
[Reference assemblies](https://github.com/dotnet/roslyn/blob/master/docs/features/refout.md) are assemblies which only contain metadata but no executable IL code.

### Why would you need this?
Sometimes you do not want to ship executable code but only metadata for developers to interact with your product.
This can be especially useful if other developers are developing integrations (add-ons or plug-ins) to your proprietary product.
You can then just provide your reference assembly to them. They will not need access to your product.

### Usage

`dotnet tool install ReferenceAssemblyGenerator <-g|--global>`

`dotnet refgen -- [-f|--force] [-o|--output <outputfile>] <assemblyPath>`

### License
[MIT](https://github.com/Tyler-IN/ReferenceAssemblyGenerator/blob/master/LICENSE)

### ReferenceAssemblyGenerator vs. Rosyln (/refout and /refonly)
The C# and Visual Basic .NET compiler (Rosyln) contains the similar options [/refout and /refonly](https://github.com/dotnet/roslyn/blob/master/docs/features/refout.md).

* Rosyln can only generate reference assemblies if you have the full source code. ReferenceAssemblyGenerator does not need source code, only the binary files.
