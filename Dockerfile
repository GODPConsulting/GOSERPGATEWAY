FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["TollGates/TollGates.csproj", "TollGates/"]
RUN dotnet restore "TollGates/TollGates.csproj"
COPY . .
WORKDIR "/src/TollGates"
RUN dotnet build "TollGates.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TollGates.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TollGates.dll"]