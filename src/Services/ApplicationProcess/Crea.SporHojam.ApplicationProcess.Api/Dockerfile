#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Services/ApplicationProcess/Crea.SporHojam.ApplicationProcess.Api/Crea.SporHojam.ApplicationProcess.Api.csproj", "src/Services/ApplicationProcess/Crea.SporHojam.ApplicationProcess.Api/"]
RUN dotnet restore "src/Services/ApplicationProcess/Crea.SporHojam.ApplicationProcess.Api/Crea.SporHojam.ApplicationProcess.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/ApplicationProcess/Crea.SporHojam.ApplicationProcess.Api"
RUN dotnet build "Crea.SporHojam.ApplicationProcess.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Crea.SporHojam.ApplicationProcess.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Crea.SporHojam.ApplicationProcess.Api.dll"]