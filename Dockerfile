#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Epila.Ph.Api/Epila.Ph.Api/Epila.Ph.Api.csproj", "Epila.Ph.Api/Epila.Ph.Api/"]
RUN dotnet restore "Epila.Ph.Api/Epila.Ph.Api/Epila.Ph.Api.csproj"
COPY . .
WORKDIR "/src/Epila.Ph.Api/Epila.Ph.Api"
RUN dotnet build "Epila.Ph.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Epila.Ph.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Epila.Ph.Api.dll"]