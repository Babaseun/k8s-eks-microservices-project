# Use multi-stage build for different architectures
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release
ARG ASPNETCORE_ENVIRONMENT=Production
WORKDIR /src

# Copy csproj file and restore dependencies
COPY ["ProductService.csproj", "./"]

# Retry restoring with limited resources to avoid segmentation fault
RUN dotnet restore "ProductService.csproj" --no-cache --ignore-failed-sources || \
    (echo "Retrying dotnet restore after failure" && dotnet restore "ProductService.csproj")

# Copy everything else and build
COPY . .
RUN dotnet build "ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/build || \
    (echo "Retrying dotnet build after failure" && dotnet build "ProductService.csproj" -c $BUILD_CONFIGURATION -o /app/build)

# Publish stage
FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .

# Set the environment variable in the Docker container
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
ENTRYPOINT ["dotnet", "ProductService.dll"]
