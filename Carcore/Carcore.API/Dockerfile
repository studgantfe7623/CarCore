#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Carcore.API/Carcore.API.csproj", "Carcore.API/"]
RUN dotnet restore "Carcore.API/Carcore.API.csproj"
COPY . .
WORKDIR "/src/Carcore.API"
RUN dotnet build "Carcore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carcore.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

LABEL version="1.0.0"
LABEL release="1"
LABEL Name="Felix Ganterer <felix.ganterer@stud.th-rosenheim.de>"
LABEL Vendor="Microsoft"

ENTRYPOINT ["dotnet", "Carcore.API.dll"]