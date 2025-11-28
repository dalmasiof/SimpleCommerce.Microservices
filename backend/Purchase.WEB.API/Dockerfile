# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Purchase.WEB.API/Purchase.WEB.API.csproj", "Purchase.WEB.API/"]
COPY ["Purchase.Application/Purchase.Application.csproj", "Purchase.Application/"]
COPY ["Purchase.Infra/Purchase.Infra.csproj", "Purchase.Infra/"]
COPY ["Purchase.Domain/Purchase.Domain.csproj", "Purchase.Domain/"]
COPY ["../Sharedkernel/Sharedkernel.csproj", "../Sharedkernel/"]
RUN dotnet restore "./Purchase.WEB.API/Purchase.WEB.API.csproj"
COPY . .
WORKDIR "/src/Purchase.WEB.API"
RUN dotnet build "./Purchase.WEB.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Purchase.WEB.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in Purchaseion or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Purchase.WEB.API.dll"]