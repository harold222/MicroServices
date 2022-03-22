# colocar condicional para el coordinador que no usa el shared

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
ARG NAME_PROJECT
ENV NAME_PROJECT=${NAME_PROJECT}
COPY ["$NAME_PROJECT/$NAME_PROJECT/$NAME_PROJECT.csproj", "$NAME_PROJECT/$NAME_PROJECT/"]
COPY ["shared/shared.csproj", "shared/"]
RUN dotnet restore "$NAME_PROJECT/$NAME_PROJECT/$NAME_PROJECT.csproj"
COPY . .
WORKDIR "/src/$NAME_PROJECT/$NAME_PROJECT"
RUN dotnet build "$NAME_PROJECT.csproj" -c Release -o /app/build

FROM build AS publish
ARG NAME_PROJECT
ENV NAME_PROJECT=${NAME_PROJECT}
RUN dotnet publish "$NAME_PROJECT.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ARG NAME_PROJECT
ENV NAME_PROJECT=${NAME_PROJECT}
COPY --from=publish /app/publish .
ENTRYPOINT dotnet $NAME_PROJECT.dll