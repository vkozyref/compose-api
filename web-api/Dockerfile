FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.6-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2.6-stretch AS build
WORKDIR /src
COPY web-api/web-api.csproj web-api/
RUN dotnet restore "web-api/web-api.csproj"
COPY . .
WORKDIR "/src/web-api"
RUN dotnet build "web-api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "web-api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "web-api.dll"]
