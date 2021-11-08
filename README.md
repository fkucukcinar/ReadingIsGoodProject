# ReadingIsGood Project
**`Book Store `** project to create customers and order books and lists orders.

In this project used;


-.Net Core 5 Web API

-ORM: Entity Framework Core (Code First & Migration)

-Validation: FluentValidation

-Mapping: AutoMapper

-Logging: Serilog

-Authentication: JWT Identity 

-Open API Specification: Swagger

For Login;

**`UserName`**: fehmik

**`Password`**: Test@1234

For Login Customer: **`localhost:<your_port>/api/Login/login`**

For Add New Customer: **`localhost:<your_port>/api/Customer/CreateCustomer`**

For Customer's Order List: **`localhost:yourport/api/Order/GetOrders/{customerId}`**

For Order Details: **`localhost:yourport/api/OrderDetail/GetOrderDetails/{orderId}`**

Here are jwt token settings;


    "JwtToken":  

      {

        "SecretKey": "thisisasecretkeyanddontsharewithanyone", 

        "Issuer": "your issue address"

        
      }
  
  
Serilog Settings: BookStore.Api -> appsettings.json

Here are Serilog settings;

    "Serilog": {
    "Using": [ "Serilog.Exceptions", "Serilog", "Serilog.Sinks.Console", "Serilog.Sinks.Seq" ],
    "MinimumLevel": {
      "Default": "Verbose",
      "Override": {
        "System": "Information",
        "Microsoft": "Information",
        "Microsoft.EntityFrameworkCore": "Information"
      }
    },
    "WriteTo": [
      {
        "Name": "Seq",
        "Args": {
          "serverUrl": "http://localhost:5341",
          "apiKey": "none",
          "restrictedToMinimumLevel": "Verbose"
        }
      },
      {
        "Name": "Async",
        "Args": {
          "configure": [
            {
              "Name": "Console",
              "Args": {
                "restrictedToMinimumLevel": "Information"
              }
            }
          ]
        }
      }
    ],
    "Enrich": [ "FromLogContext", "WithExceptionDetails" ],
    "Properties": {
      "Environment": "LocalDev"
    }
  
 
Fehmi Kucukcinar
