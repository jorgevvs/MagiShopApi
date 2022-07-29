#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MagicShop.Card/MagicShop.CardAPI.csproj", "MagicShop.Card/"]
COPY ["MagicShopApi.Domain/MagicShop.Common.csproj", "MagicShopApi.Domain/"]
COPY ["MagicShopApi.App/MagicShop.API.csproj", "MagicShopApi.App/"]
RUN dotnet restore "MagicShop.Card/MagicShop.CardAPI.csproj"
COPY . .
WORKDIR "/src/MagicShop.Card"
RUN dotnet build "MagicShop.CardAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagicShop.CardAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagicShop.CardAPI.dll"]
