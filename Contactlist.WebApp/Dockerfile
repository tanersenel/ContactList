#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Contactlist.WebApp/Contactlist.WebApp.csproj", "Contactlist.WebApp/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
COPY ["Contactlist.Reporting/Contactlist.Reporting.csproj", "Contactlist.Reporting/"]
RUN dotnet restore "Contactlist.WebApp/Contactlist.WebApp.csproj"
COPY . .
WORKDIR "/src/Contactlist.WebApp"
RUN dotnet build "Contactlist.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contactlist.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contactlist.WebApp.dll"]
