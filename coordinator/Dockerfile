FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY coordinator ./
RUN dotnet restore
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/sdk:5.0
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=local
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:80  
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "coordinator.dll"]

# docker build -t coordinator .
# docker run -it --rm -p 5000:80 --name coordinator coordinator