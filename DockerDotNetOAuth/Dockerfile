FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["DockerDotNetOAuth/DockerDotNetOAuth.csproj", "DockerDotNetOAuth/"]
RUN dotnet restore "DockerDotNetOAuth/DockerDotNetOAuth.csproj"
COPY . .
WORKDIR "/src/DockerDotNetOAuth"
RUN dotnet build "DockerDotNetOAuth.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerDotNetOAuth.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerDotNetOAuth.dll"]