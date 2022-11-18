#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MusharafPortal.Core.Api/Musharaf.Portal.Core.Api.csproj", "MusharafPortal.Core.Api/"]
RUN dotnet restore "MusharafPortal.Core.Api/Musharaf.Portal.Core.Api.csproj"
COPY . .
WORKDIR "/src/MusharafPortal.Core.Api"
RUN dotnet build "Musharaf.Portal.Core.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Musharaf.Portal.Core.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Musharaf.Portal.Core.Api.dll"]