#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Resourceedge.Authentication.API/Resourceedge.Authentication.API.csproj", "Resourceedge.Authentication.API/"]
RUN dotnet restore "Resourceedge.Authentication.API/Resourceedge.Authentication.API.csproj"
COPY . .
WORKDIR "/src/Resourceedge.Authentication.API"
RUN dotnet build "Resourceedge.Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Resourceedge.Authentication.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Resourceedge.Authentication.API.dll"]
