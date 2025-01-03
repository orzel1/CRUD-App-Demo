# Budowanie apki

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./EmployeeAPI/EmployeeAPI.csproj" --disable-parallel # Dolacz pakiety NuGet
RUN dotnet publish "./EmployeeAPI/EmployeeAPI.csproj" -c release -o /app --no-restore # Opublikuj apke
RUN ls -la /app
# Uruchamianie

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "EmployeeAPI.dll"]

# docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 orzel/employee-api
