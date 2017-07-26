# Mock-Car-Dealership

This is a mock car dealership full-stack web application utilizing ASP.NET MVC framework. Data storage is implemented via ADO.NET to a SQL Server instance.  Client-side will be implemented using C# Razor, HTML, CSS, BootStrap, and JavaScript/JQuery.

There will be two modes this application can run in, "QA" using an in-memory mock repository for testing, and "Production" using ASP.NET ADO and a SQL Server database instance.  These modes will be selectable using web.congig's appSettings Key "Mode" and entering either of the above modes as the referenced value.

The dependency injection will be managed by Microsoft's Unity Framework.

Application user tables in the database were migrated using Entity Framework with ASP.Identity managing security and user roles.




