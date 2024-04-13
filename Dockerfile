# # Use the official ASP.NET Core runtime image as the base image
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# WORKDIR /app
# EXPOSE 80

# # Copy the published output of the ASP.NET Core application to the container
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# WORKDIR /src
# COPY ["TodoApi.csproj", "TodoApi/"]
# RUN dotnet restore "TodoApi/TodoApi.csproj"
# COPY . .
# WORKDIR "/src/TodoApi"
# RUN dotnet build "TodoApi.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "TodoApi.csproj" -c Release -o /app/publish

# # Use the base image and copy the published output of the ASP.NET Core application
# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "TodoApi.dll"]





FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./TodoApi.csproj"

WORKDIR "/src/."
RUN dotnet build "TodoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "TodoApi.dll","--server.urls","http://*/80"]





# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# # RUN apt update && apt install -qq -y ffmpeg && rm -rf /var/lib/apt/lists/*

# # For local docker run added more depth to FolderPath
# WORKDIR /app/web
# EXPOSE 80

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY . .
# RUN dotnet restore "OutPlay.Web/OutPlay.Web.csproj"
# RUN curl -sL https://deb.nodesource.com/setup_16.x |  bash -

# WORKDIR "/src/OutPlay.Web"
# RUN apt-get install -y nodejs
# RUN npm ci
# RUN npm run prod
# # RUN dotnet build "OutPlay.Web.csproj" -c Debug -o /app/web/build

# FROM build AS publish
# RUN dotnet publish "OutPlay.Web.csproj" -c Debug -o /app/web/publish

# FROM base AS final
# WORKDIR /app/web
# COPY --from=publish /app/web/publish .
# COPY --from=build /src/OutPlay.Web/dist ./dist
# ENTRYPOINT ["dotnet", "OutPlay.Web.dll"]



