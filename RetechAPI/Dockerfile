# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    clang zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RetechAPI/Retech.API.csproj", "RetechAPI/"]
COPY ["Retech.Application/Retech.Application.csproj", "Retech.Application/"]
COPY ["Retech.Core/Retech.Core.csproj", "Retech.Core/"]
COPY ["Retech.DataAccess/Retech.DataAccess.csproj", "Retech.DataAccess/"]
RUN dotnet restore "./RetechAPI/Retech.API.csproj"
COPY . .
WORKDIR "/src/RetechAPI"
RUN dotnet build "./Retech.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Retech.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./Retech.API"]