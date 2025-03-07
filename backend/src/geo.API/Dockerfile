FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/geo.API/geo.API.csproj", "src/geo.API/"]
COPY ["src/geo.Application/geo.Application.csproj", "src/geo.Application/"]
COPY ["src/geo.Domain/geo.Domain.csproj", "src/geo.Domain/"]
COPY ["src/geo.Infrastructure/geo.Infrastructure.csproj", "src/geo.Infrastructure/"]
RUN dotnet restore "src/geo.API/geo.API.csproj"
COPY . .
WORKDIR "/src/src/geo.API"
RUN dotnet build "geo.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "geo.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "geo.API.dll"]
