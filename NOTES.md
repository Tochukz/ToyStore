## The DataLayer
__Nuget__  
When you install a `Nuget` package, Nuget copies the files to your project, add a `package` element referencing the t package in the `packages` element of the `packages.config` file.    
It also  adds a `Reference` element to the `ItemGroup` element of the project file (`.csproj`). The `Include` attribute of the reference element specifies the type name of the reference.  

## The Navigation UI
By setting the `ItemType` property in a `ListView` control, the data-binding expression `Item` becomes available within the `ItemTemplate` node and the control becomes strongly typed.  
By adding the `:` to the end of the `<%#` prefix, (e.g `<%#: Item.CategoryName  %>`), the result of the data-binding expression is HTML-encoded.  
