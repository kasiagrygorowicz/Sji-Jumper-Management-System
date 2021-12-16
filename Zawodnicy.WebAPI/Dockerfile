#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Zawodnicy.WebAPI/Zawodnicy.WebAPI.csproj", "Zawodnicy.WebAPI/"]
COPY ["Zawodnicy.Infrastructure/Zawodnicy.Infrastructure.csproj", "Zawodnicy.Infrastructure/"]
COPY ["Zawodnicy.Core/Zawodnicy.Core.csproj", "Zawodnicy.Core/"]
RUN dotnet restore "Zawodnicy.WebAPI/Zawodnicy.WebAPI.csproj"
COPY . .
WORKDIR "/src/Zawodnicy.WebAPI"
RUN dotnet build "Zawodnicy.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zawodnicy.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zawodnicy.WebAPI.dll"]
