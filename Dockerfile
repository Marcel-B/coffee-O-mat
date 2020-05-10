FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

# Copy only API for restore packages
COPY ["coffee-O-mat.Api/coffee-O-mat.Api.csproj", "coffee-O-mat.Api/"]

# Restore packages
RUN dotnet restore "coffee-O-mat.Api/coffee-O-mat.Api.csproj"

# Copy rest of the Project
COPY . .

# Build API
WORKDIR "/src/coffee-O-mat.Api"
RUN dotnet build "coffee-O-mat.Api.csproj" -c Release -o /app/build


# Publish
WORKDIR "/src/coffee-O-mat.Api"
FROM build AS publish
RUN dotnet publish "coffee-O-mat.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "coffee-O-mat.Api.dll"]
