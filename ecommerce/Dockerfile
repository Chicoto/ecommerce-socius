# Usar la imagen de runtime de .NET 6
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Usar la imagen de SDK de .NET 6 para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Configurar la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ecommerce.dll"]
