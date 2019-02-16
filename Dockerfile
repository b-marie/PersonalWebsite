FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/PersonalWebsite.API/PersonalWebsite.API.csproj PersonalWebsite.API/
COPY src/PersonalWebsite.Common/PersonalWebsite.Common.csproj PersonalWebsite.Common/
COPY src/PersonalWebsite.Logic/PersonalWebsite.Logic.csproj PersonalWebsite.Logic/
COPY src/PersonalWebsite.Repository/PersonalWebsite.Repository.csproj PersonalWebsite.Repository/
RUN dotnet restore PersonalWebsite.API/PersonalWebsite.API.csproj
COPY . .
WORKDIR /src/PersonalWebsite.API
RUN dotnet build PersonalWebsite.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PersonalWebsite.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "PersonalWebsite.API.dll"]
