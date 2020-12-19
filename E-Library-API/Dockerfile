# Build
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["E-Library/E-Library.csproj", "E-Library/"]
COPY ["E-Library.Application/E-Library.Application.csproj", "E-Library.Application/"]
COPY ["E-Library.DAL/E-Library.DAL.csproj", "E-Library.DAL/"]
COPY ["E-Library.Resources/E-Library.Resources.csproj", "E-Library.Resources/"]
RUN dotnet restore "./E-Library/E-Library.csproj"
COPY . .
WORKDIR "/src/E-Library/"
RUN dotnet build "E-Library.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "E-Library.csproj" -c Release -o /app/publish

# Run
FROM base AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Docker
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-Library.dll"]