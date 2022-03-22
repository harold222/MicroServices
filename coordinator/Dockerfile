FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./coordinator/coordinator.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT=local
# EXPOSE 81
EXPOSE 5000
COPY --from=build /app .
ENTRYPOINT ["dotnet", "coordinator.dll"]

# docker build -t coordinator .
# docker run -it --rm -p 5000:80 --name coordinator coordinator