# ToyStore
__Based on the tutorial__ _"[Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2013](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/)"_  

## Lesson 1: Getting Started with Web Forms and Visual Studio

## Lesson 2: Create the Project
__Additional Technologies to explore__  
* [ASP.NET Web API](https://dotnet.microsoft.com/apps/aspnet/apis)  
* [ASP.NET SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)  

__ASP.NET Web Forms Background__  
It is important to understand the [ASP.NET life cycle](https://docs.microsoft.com/en-us/previous-versions/aspnet/ms178472(v=vs.100)?redirectedfrom=MSDN) so that you can write code at the appropriate life-cycle stage for effect you intend.  

Any database or _Transact-SQL_ code can be moved from _SQL SERVER Express localDB_ to _SQL Server_ and _SQL Azure_ without any upgrade steps. So, _SQL Server Express LocalDB_ can be used as a developer environment for applications targeting all editions of _SQL Server_.

__Additional Resources__  
[Web Application Projects versus Web Site Projects](https://docs.microsoft.com/en-us/previous-versions/aspnet/dd547590(v=vs.110)?redirectedfrom=MSDN)

## Lesson 3: Create the Data Access Layer
__Nuget__  
When you install a `Nuget` package, Nuget copies the files to your project, add a `package` element referencing the t package in the `packages` element of the `packages.config` file.    
It also  adds a `Reference` element to the `ItemGroup` element of the project file (`.csproj`). The `Include` attribute of the reference element specifies the type name of the reference.  

__Creating the Data Models__   
1. Create the _Entity classes_ or Models
2. Create the _Context class_, which provides access to the database
3. Create an _Initializer class_ to seed the database.  
4. In the _Global.asax_ file, set the initializer object to initialize the database at the _Application_Start_ life cycle method.  
5. Add a connection string to _Web.config_ file. Although _Entity Framework Code First_ will generate a database for you in a default location, you can take control of where the database is located by adding your own connection string. For example, you can specify that the master data file (`ToyStore.mdf`) should be located in your data directory (_App_data_).  
6. Build the application   
7. The Database will be created by _Entity Framework_, based on the models, the first time the application is run.  

__Additional Resources__  
[Entity Framework 6](https://docs.microsoft.com/en-us/ef/ef6/?redirectedfrom=MSDN)  

## Lesson 4: UI and Navigation
By setting the `ItemType` property in a `ListView` control, the data-binding expression `Item` becomes available within the `ItemTemplate` node and the control becomes strongly typed.  
By adding the `:` to the end of the `<%#` prefix, (e.g `<%#: Item.CategoryName  %>`), the result of the data-binding expression is HTML-encoded.  

## Lesson 5: Display Data Items and Details   
__Adding a Data Control to Display Products__  
When binding data to a server control, there are a few different options you can use:  
1. Using a Data Source Control to Bind Data (abstracts the data binding).
2. Coding By Hand to Bind Data (gives you full control).
3. Using Model Binding to Bind Data  (good for code reuse, recommended for most people).

__Value Providers__  
Considering the method signature:  
```
public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
{
  ...
  IQueryable<Product> products = products.Where(p => p.CategoryID == categoryId);
  ...
}
```
the `QueryString` attribute is referred to as a _value provider_ and the `"id"` argument passed to the value provider is called the _value provider attribute_. There are other value provider that handles cookies, form values, controls, view state, session state and profile properties. You can also write your own custom value providers.

__Versioning__
Version can be specified in the `AssemblyInfo.cs` file.  See [Stack Oveflow](https://stackoverflow.com/questions/64602/what-are-differences-between-assemblyversion-assemblyfileversion-and-assemblyin) for more on this.

## Lesson 6: Shopping Cart  
By default a Session states are stored in-process on the web server hosting the web application. The use of Session State stored in-process to store user-specific information may work well for demonstration purposes and for small websites but may have performance implications for larger sites.  For larger websites and sites that run multiple instances, it is recommended to use an external provider such as _Window Azure Cache Service_. The Cache Service provides a distributed caching service that is external to the web site and solves the problem of using in-process session state.  [Learn more](https://docs.microsoft.com/en-us/azure/azure-cache-for-redis/cache-aspnet-session-state-provider)

## Lesson 7: Checkout and Payment with PayPal
