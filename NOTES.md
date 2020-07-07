__Nuget__  
When you install a `Nuget` package, Nuget copies the files to your project, add a `package` element referencing the t package in the `packages` element of the `packages.config` file.    
It also  adds a `Reference` element to the `ItemGroup` element of the project file (`.csproj`). The `Include` attribute of the reference element specifies the type name of the reference.  
  
