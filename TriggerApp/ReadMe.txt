Building a web app with Ap.NET MVC core in Pluralsight.
Source Code of ASP.NET Core 2.0 -> https://github.com/aspnet
Microst ASP.NET Core Documentation - >https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup
This is the Testing Test
==========================================================================================================================

Singnificance of the Program.cs Class in ASP.NET core 2.0
==========================================================================================================================
https://wildermuth.com/2017/07/06/Program-cs-in-ASP-NET-Core-2-0
==========================================================================================================================

Singificance of the Program.cs
==========================================================================================================================
* It is the main process entry point to ignite the host to start listening the request in case of ASP.NET core. As it is 
cross platform thus not tied to only IIS. 
If we put a blocking operation in Main() e.g. Console.Readline() , the web server will never started and it will appear 
never completing loop circles in the browser on the strat up. If we put nothing then it just started and stop in a blink.

* https://wildermuth.com/2017/07/06/Program-cs-in-ASP-NET-Core-2-0
* http://www.c-sharpcorner.com/article/asp-net-core-api-day-one-getting-started-and-request-pipeline/

Significance of StartUp.cs
==========================================================================================================================
*This is the startup bootstarp which has been injected through .UseStartup<Startup>(). In the Starup class the Configure()
method is a must otherwise server could not be started as host could not be able to configured by the runtime. The 
"Configure()" method is a dependency that comes with ASP.NET core modules.

* In side the "configure()" method the the parameters are injected through DI. If the configure method is empty then also 
the host does not know what should be done after the application is up thus going to throw an exception.

Static File Serving outof wwwroot
===========================================================================================================================
web root = (<content-root>/wwwroot) folder
http://jakeydocs.readthedocs.io/en/latest/fundamentals/static-files.html
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files

* To Serve the Static files out side the "wwwroot" folder, either use .UseWebRoot() + app.StaticFiles(requestPath) 
or
app.UseStaticFiles(new StaticFileOptions() with code given above two link