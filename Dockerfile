# Utiliza la imagen oficial de .NET 9 para construir y publicar la app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ms-net-store-usuarios.sln
RUN dotnet publish UsuariosApi.csproj -c Release -o /app/publish

# Utiliza la imagen de runtime para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "UsuariosApi.dll"]