# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build


WORKDIR /source
COPY . . 
RUN dotnet restore "./app/Carcore/Carcore.csproj" 
RUN dotnet publish "./app/Carcore/Carcore.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 
WORKDIR /app
COPY --from=build /app ./

LABEL version="1.0.0"
LABEL release="1"
LABEL Name="Felix Ganterer <felix.ganterer@stud.th-rosenheim.de>"
LABEL Vendor="Microsoft"

ENTRYPOINT ["dotnet", "Carcore.dll"]
