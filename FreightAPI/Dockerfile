## See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
## These ARGs allow for swapping out the base used to make the final image when debugging from VS
#ARG LAUNCHING_FROM_VS
## This sets the base image for final, but only if LAUNCHING_FROM_VS has been defined
#ARG FINAL_BASE_IMAGE=${LAUNCHING_FROM_VS:+aotdebug}
## This stage is used when running from VS in fast mode (Default for Debug configuration)
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
## This stage is used to build the service project
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
## Removed clang/zlib1g-dev dependencies since AOT is disabled
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["FreightAPI/FreightAPI.csproj", "FreightAPI/"]
#RUN dotnet restore "./FreightAPI/FreightAPI.csproj"
#COPY . .
#WORKDIR "/src/FreightAPI"
#RUN dotnet build "./FreightAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build
## This stage is used to publish the service project to be copied to the final stage
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./FreightAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
## This stage is used as the base for the final stage when launching from VS to support debugging in regular mode (Default when not using the Debug configuration)
#FROM base AS aotdebug
#USER root
## Install GDB to support native debugging
#RUN apt-get update \
    #&& apt-get install -y --no-install-recommends \
    #gdb
#USER app
## This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
#FROM ${FINAL_BASE_IMAGE:-mcr.microsoft.com/dotnet/aspnet:8.0} AS final
#WORKDIR /app
#EXPOSE 8080
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "FreightAPI.dll"]

# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FreightAPI/FreightAPI.csproj", "FreightAPI/"]
RUN dotnet restore "./FreightAPI/FreightAPI.csproj"
COPY . .
WORKDIR "/src/FreightAPI"
RUN dotnet build "./FreightAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FreightAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreightAPI.dll"]
