FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

COPY ./src/App/*.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish DigitalLibrarySolution.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT [ "dotnet", "App.dll" ]
