#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./application/Nibo.ConciliatorOFX.Application.API/Nibo.ConciliatorOFX.Application.API.csproj", "src/application/Nibo.ConciliatorOFX.Application.API/"]
COPY ["./data/Nibo.ConciliatorOFX.Data/Nibo.ConciliatorOFX.Data.csproj", "src/data/Nibo.ConciliatorOFX.Data/"]
COPY ["./domain/Nibo.ConciliatorOFX.Domain/Nibo.ConciliatorOFX.Domain.csproj", "src/domain/Nibo.ConciliatorOFX.Domain/"]

RUN dotnet restore "src/application/Nibo.ConciliatorOFX.Application.API/Nibo.ConciliatorOFX.Application.API.csproj"
COPY . .
WORKDIR "application/Nibo.ConciliatorOFX.Application.API/"
RUN dotnet build "Nibo.ConciliatorOFX.Application.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nibo.ConciliatorOFX.Application.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nibo.ConciliatorOFX.Application.API.dll"]