# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos del proyecto
COPY . ./

# Restaurar paquetes y publicar la app
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Puerto por defecto
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "CineMVC.dll"]
