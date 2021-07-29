#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarService.RepariOrders.Api/CarService.RepairOrders.Api.csproj", "CarService.RepariOrders.Api/"]
COPY ["CarService.AppCore/CarService.AppCore.csproj", "CarService.AppCore/"]
COPY ["CarService.Domain/CarService.Domain.csproj", "CarService.Domain/"]
RUN dotnet restore "CarService.RepariOrders.Api/CarService.RepairOrders.Api.csproj"
COPY . .
WORKDIR "/src/CarService.RepariOrders.Api"
RUN dotnet build "CarService.RepairOrders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarService.RepairOrders.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarService.RepairOrders.Api.dll"]
