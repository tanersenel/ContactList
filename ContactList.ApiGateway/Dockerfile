#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ContactList.ApiGateway/ContactList.ApiGateway.csproj", "ContactList.ApiGateway/"]
RUN dotnet restore "ContactList.ApiGateway/ContactList.ApiGateway.csproj"
COPY . .
WORKDIR "/src/ContactList.ApiGateway"
RUN dotnet build "ContactList.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactList.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactList.ApiGateway.dll"]
