FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Kopiere die csproj-Datei und restauriere die Abhängigkeiten
COPY *.csproj ./
RUN dotnet restore

# Kopiere den Rest des Codes und führe ein Build aus
COPY . ./
RUN dotnet publish -c Release -o out

# Nutze das .NET Runtime-Image als Basis für den finalen Container
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Definiere den Startbefehl für den Container
ENTRYPOINT ["dotnet", "RentalCar.dll"]
