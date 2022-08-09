FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR "./rwe-test-web"
COPY ["./rwe.worker/rwe.worker.csproj", "app/"]
RUN dotnet restore "app/rwe.worker.csproj"
COPY . .
WORKDIR "/rwe-test-web/rwe.worker"
RUN dotnet build "rwe.worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rwe.worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rwe.worker.dll"]
