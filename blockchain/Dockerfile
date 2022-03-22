FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY --from=../shared/shared.csproj ./
RUN dotnet publish -c Release -o 'release' shared 

# COPY blockchain ./
# RUN dotnet restore

# COPY ["shared/shared.csproj", "./shared"]
# RUN dotnet publish -c Release -o 'release' shared 

# RUN dotnet publish -c release -o out

# FROM mcr.microsoft.com/dotnet/sdk:5.0
# ARG BUILD_CONFIGURATION=Debug
# ENV ASPNETCORE_ENVIRONMENT=local
# ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
# ENV ASPNETCORE_URLS="http://*:5001"
# WORKDIR /app
# COPY --from=build /app/out ./

# EXPOSE 5001
# ENTRYPOINT ["dotnet", "blockchain.dll"]

# docker build -t blockchain .
# docker run -it -p 5001:80 --name BlockChain blockchain