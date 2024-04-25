FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 5000

ENV ASPNETCORE_URLS http://*:5000

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build



WORKDIR /src
COPY   /DesafioPaschoalotto.sln ./
COPY  ./DesafioPaschoalotto.Domain/*.csproj ./DesafioPaschoalotto.Domain/
COPY  ./DesafioPaschoalotto.Application/*.csproj ./DesafioPaschoalotto.Application/
COPY  ./DesafioPaschoalotto.Infrastructure/*.csproj ./DesafioPaschoalotto.Infrastructure/
COPY  ./DesafioPaschoalotto.IoC/*.csproj ./DesafioPaschoalotto.IoC/
COPY  ./DesafioPaschoalotto.Api/*.csproj ./DesafioPaschoalotto.Api/
COPY  ./DesafioPaschoalotto.Test/*.csproj ./DesafioPaschoalotto.Test/


RUN dotnet restore
COPY . .
WORKDIR /src/DesafioPaschoalotto.Domain
RUN dotnet build -c Debug -o /app

WORKDIR /src/DesafioPaschoalotto.Infrastructure
RUN dotnet build -c Debug -o /app

WORKDIR /src/DesafioPaschoalotto.IoC
RUN dotnet build -c Debug -o /app

WORKDIR /src/DesafioPaschoalotto.Api
RUN dotnet build -c Debug -o /app

FROM build AS publish
RUN dotnet publish -c Debug -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DesafioPaschoalotto.Api.dll"]