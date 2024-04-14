
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 80

# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# COPY . .
# COPY mydatabase.db /app/src
# RUN dotnet restore "./backend.csproj"

# WORKDIR "/src/."
# RUN dotnet build "backend.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "backend.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENV ASPNETCORE_URLS=http://+:80
# ENTRYPOINT ["dotnet", "backend.dll","--server.urls","http://*/80"]



FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN echo $(find . -name "mydatabase.db")
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
COPY mydatabase.db /app/Data
RUN echo $(find . -name "mydatabase.db")

RUN dotnet restore "./backend.csproj"

WORKDIR "/src/."
RUN dotnet build "backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

# Consider injecting connection string from configuration (recommended)
# See comments below for details

# OR (if not injecting)
# COPY appsettings.json .  # Optional (if using appsettings.json)

COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "backend.dll","--server.urls","http://*/80"]
