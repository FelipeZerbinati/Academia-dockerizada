#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Academia10.Api/Academia10.Api.csproj", "Academia10.Api/"]
COPY ["Academia.Domain/Academia10.Domain.csproj", "Academia.Domain/"]
COPY ["Academia10.Application/Academia10.Application.csproj", "Academia10.Application/"]
COPY ["Academia10.Data/Academia10.Data.csproj", "Academia10.Data/"]
COPY ["Academia.Data.Postgres/Academia10.Data.Postgres.csproj", "Academia.Data.Postgres/"]
RUN dotnet restore "./Academia10.Api/Academia10.Api.csproj"
COPY . .
WORKDIR "/src/Academia10.Api"
RUN dotnet build "./Academia10.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Academia10.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Academia10.Api.dll"]