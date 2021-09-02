#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["../CarService.Authentication/CarService.Authentication.csproj", "../CarService.Authentication/"]
RUN dotnet restore "../CarService.Authentication/CarService.Authentication.csproj"
COPY . .
WORKDIR "/src/../CarService.Authentication"
RUN dotnet build "CarService.Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarService.Authentication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarService.Authentication.dll"]