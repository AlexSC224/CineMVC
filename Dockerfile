# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos del proyecto y restaurar
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el contenido y publicar
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto 80
EXPOSE 80

# Comando para iniciar la app
ENTRYPOINT ["dotnet", "CineMVC.dll"]
