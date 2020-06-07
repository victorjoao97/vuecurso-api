FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ProjectSchool_API.csproj", "./"]
RUN dotnet restore "./ProjectSchool_API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ProjectSchool_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectSchool_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectSchool_API.dll"]
