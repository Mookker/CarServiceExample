#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarService.Api.GraphQL/CarService.Api.GraphQL.csproj", "CarService.Api.GraphQL/"]
COPY ["CarService.Infrastructure.MongoDb/CarService.Infrastructure.MongoDb.csproj", "CarService.Infrastructure.MongoDb/"]
COPY ["CarService.AppCore/CarService.AppCore.csproj", "CarService.AppCore/"]
COPY ["CarService.Domain/CarService.Domain.csproj", "CarService.Domain/"]
COPY ["CarService.Cqrs/CarService.Cqrs.csproj", "CarService.Cqrs/"]
RUN dotnet restore "CarService.Api.GraphQL/CarService.Api.GraphQL.csproj"
COPY . .
WORKDIR "/src/CarService.Api.GraphQL"
RUN dotnet build "CarService.Api.GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarService.Api.GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarService.Api.GraphQL.dll"]
