#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
RUN mkdir testDir
RUN mkdir EmailTemplate
COPY ["Resourceedge.Appraisal.API/EmailTemplate", "/app/EmailTemplate"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Resourceedge.Appraisal.API/Resourceedge.Appraisal.API.csproj", "Resourceedge.Appraisal.API/"]
COPY ["Resourceedge.Appraisal.Domain/Resourceedge.Appraisal.Domain.csproj", "Resourceedge.Appraisal.Domain/"]
COPY ["Resourceedge.Common/Resourceedge.Common.csproj", "Resourceedge.Common/"]
RUN dotnet restore "Resourceedge.Appraisal.API/Resourceedge.Appraisal.API.csproj"
COPY . .
WORKDIR "/src/Resourceedge.Appraisal.API"
RUN dotnet build "Resourceedge.Appraisal.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Resourceedge.Appraisal.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN mkdir AppraisalResult 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Resourceedge.Appraisal.API.dll"]
