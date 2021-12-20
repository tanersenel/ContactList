#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Contactlist.Reporting/Contactlist.Reporting.csproj", "Contactlist.Reporting/"]
RUN dotnet restore "Contactlist.Reporting/Contactlist.Reporting.csproj"
COPY . .
WORKDIR "/src/Contactlist.Reporting"
RUN dotnet build "Contactlist.Reporting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contactlist.Reporting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contactlist.Reporting.dll"]
