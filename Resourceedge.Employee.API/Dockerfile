#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Resourceedge.Employee.API/Resourceedge.Employee.API.csproj", "Resourceedge.Employee.API/"]
RUN dotnet restore "Resourceedge.Employee.API/Resourceedge.Employee.API.csproj"
COPY . .
WORKDIR "/src/Resourceedge.Employee.API"
RUN dotnet build "Resourceedge.Employee.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Resourceedge.Employee.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Resourceedge.Employee.API.dll"]