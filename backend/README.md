# dotnet package
$ dotnet tool install --global dotnet-ef
$ dotnet tool update --global dotnet-ef
$ dotnet add package Microsoft.EntityFrameworkCore.Design
$ dotnet ef
$ dotnet add package Dapper
$ dotnet add package Newtonsoft.Json
$ dotnet add package Swashbuckle.AspNetCore.Swagger --version 6.5.0

# database Migration Script
$ dotnet ef migrations add InitialCreate
$ dotnet ef database update


