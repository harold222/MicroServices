FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["blockchain/blockchain/blockchain.csproj", "blockchain/blockchain/"]
COPY ["shared/shared.csproj", "shared/"]
RUN dotnet restore "blockchain/blockchain/blockchain.csproj"
COPY . .
WORKDIR "/src/blockchain/blockchain"
RUN dotnet build "blockchain.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "blockchain.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "blockchain.dll"]