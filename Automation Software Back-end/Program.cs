var builder = WebApplication.CreateBuilder(args) // builder object, responsible for application configuration with command line argument features

builder.Services.AddSingleton<DataService>(); // Singleton lifetime linking the Dependency Injection class, DataService to the application builder
builder.Services.AddSingleton<SeleniumContainer>(); // Singleton lifetime linking the Automation class, SeleniumAutomation to the application builder

var app = builder.Build(); // applcation object creation, ready for http requests and routing. Fully configured application. 

app.UseRouting(); // enables middleware, allowing for routing abilities to be accessed and implemented into the application object

app.MapControllers(); // Configures routing to API controllers, links to application object

app.Run();
