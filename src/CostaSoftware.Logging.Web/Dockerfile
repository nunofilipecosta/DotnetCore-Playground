#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CostaSoftware.Logging.Web/CostaSoftware.Logging.Web.csproj", "src/CostaSoftware.Logging.Web/"]
RUN dotnet restore "src/CostaSoftware.Logging.Web/CostaSoftware.Logging.Web.csproj"
COPY . .
WORKDIR "/src/src/CostaSoftware.Logging.Web"
RUN dotnet build "CostaSoftware.Logging.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CostaSoftware.Logging.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CostaSoftware.Logging.Web.dll"]