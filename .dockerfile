# src/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

# 1) Só os .csproj, para o restore ficar em cache
COPY StoreApi.Api/StoreApi.Api.csproj StoreApi.Api/
COPY StoreApi.Application/StoreApi.Application/StoreApi.Application.csproj StoreApi.Application/StoreApi.Application/
COPY StoreApi.Communication/StoreApi.Communication/StoreApi.Communication.csproj StoreApi.Communication/StoreApi.Communication/
COPY StoreApi.Domain/StoreApi.Domain/StoreApi.Domain.csproj StoreApi.Domain/StoreApi.Domain/
COPY StoreApi.Exception/StoreApi.Exception/StoreApi.Exception.csproj StoreApi.Exception/StoreApi.Exception/
COPY StoreApi.Infrastructure/StoreApi.Infrastructure/StoreApi.Infrastructure.csproj StoreApi.Infrastructure/StoreApi.Infrastructure/
RUN dotnet restore StoreApi.Api/StoreApi.Api.csproj

# 2) Código e publish
COPY . .
RUN dotnet publish StoreApi.Api/StoreApi.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

COPY --from=build /app/publish .

USER $APP_UID
ENTRYPOINT ["dotnet", "StoreApi.Api.dll"]