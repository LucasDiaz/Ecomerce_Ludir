# 1. Etapa de Base (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# 2. Etapa de Compilación (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos .csproj de cada módulo para restaurar dependencias
COPY ["Ecomerce_Ludir/Ecomerce_Ludir.csproj", "Ecomerce_Ludir/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# Restaurar paquetes NuGet
RUN dotnet restore "Ecomerce_Ludir/Ecomerce_Ludir.csproj"

# Copiar el resto del código y compilar
COPY . .
WORKDIR "/src/Ecomerce_Ludir"
RUN dotnet build "Ecomerce_Ludir.csproj" -c Release -o /app/build

# 3. Etapa de Publicación
FROM build AS publish
RUN dotnet publish "Ecomerce_Ludir.csproj" -c Release -o /app/publish

# 4. Etapa Final (Imagen liviana para correr la app)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecomerce_Ludir.dll"]