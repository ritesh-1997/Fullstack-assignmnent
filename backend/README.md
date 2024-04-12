dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef

dotnet ef migrations add init
dotnet ef migrations script {name}
dotnet ef database update

dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations add AddBlogCreatedTimestamp

dotnet add package Dapper

--DB
dotnet ef migrations script

dotnet add package Newtonsoft.Json
dotnet add package Swashbuckle.AspNetCore.Swagger --version 6.5.0
