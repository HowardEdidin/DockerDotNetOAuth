FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["FhirConnectV2/FhirConnectV2.csproj", "FhirConnectV2/"]
RUN dotnet restore "FhirConnectV2/FhirConnectV2.csproj"
COPY . .
WORKDIR "/src/FhirConnectV2"
RUN dotnet build "FhirConnectV2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FhirConnectV2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FhirConnectV2.dll"]