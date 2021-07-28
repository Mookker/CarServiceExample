#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarService.RepairOrders.Messenger/CarService.EventProcessor.csproj", "CarService.RepairOrders.Messenger/"]
COPY ["CarService.Infrastructure.MongoDb/CarService.Infrastructure.MongoDb.csproj", "CarService.Infrastructure.MongoDb/"]
COPY ["CarService.AppCore/CarService.AppCore.csproj", "CarService.AppCore/"]
COPY ["CarService.Domain/CarService.Domain.csproj", "CarService.Domain/"]
COPY ["CarService.Cqrs/CarService.Cqrs.csproj", "CarService.Cqrs/"]
RUN dotnet restore "CarService.RepairOrders.Messenger/CarService.EventProcessor.csproj"
COPY . .
WORKDIR "/src/CarService.RepairOrders.Messenger"
RUN dotnet build "CarService.EventProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarService.EventProcessor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarService.EventProcessor.dll"]