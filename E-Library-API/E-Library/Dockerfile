FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["E-Library.csproj", ""]
COPY ["E-Library.Application/E-Library.Application.csproj", "E-Library.Application/"]
COPY ["E-Library.DAL/E-Library.DAL.csproj", "E-Library.DAL/"]
COPY ["E-Library.Resources/E-Library.Resources.csproj", "E-Library.Resources/"]
RUN dotnet restore "./E-Library.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "E-Library.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "E-Library.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-Library.dll"]