#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1803 AS build
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