# ToyStore
## The DataLayer
__Nuget__  
When you install a `Nuget` package, Nuget copies the files to your project, add a `package` element referencing the t package in the `packages` element of the `packages.config` file.    
It also  adds a `Reference` element to the `ItemGroup` element of the project file (`.csproj`). The `Include` attribute of the reference element specifies the type name of the reference.  

## The Navigation UI
By setting the `ItemType` property in a `ListView` control, the data-binding expression `Item` becomes available within the `ItemTemplate` node and the control becomes strongly typed.  
By adding the `:` to the end of the `<%#` prefix, (e.g `<%#: Item.CategoryName  %>`), the result of the data-binding expression is HTML-encoded.  

## Display Product  
Considering the method signature  
```
public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
{

}
```
the `QueryString` parameter is referred to as a _value provider_ and the `id` passed to the value provider is called the _value provider attribute_. There are other value provider that handles cookies, form values, controls, view state, session state and profile properties. You can also write your own custom value providers.
