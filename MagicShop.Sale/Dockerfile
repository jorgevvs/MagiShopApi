#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MagicShop.Sale/MagicShop.SaleAPI.csproj", "MagicShop.Sale/"]
COPY ["MagicShopApi.Domain/MagicShop.Common.csproj", "MagicShopApi.Domain/"]
COPY ["MagicShop.User/MagicShop.UserAPI.csproj", "MagicShop.User/"]
COPY ["MagicShopApi.App/MagicShop.API.csproj", "MagicShopApi.App/"]
COPY ["MagicShop.Card/MagicShop.CardAPI.csproj", "MagicShop.Card/"]
RUN dotnet restore "MagicShop.Sale/MagicShop.SaleAPI.csproj"
COPY . .
WORKDIR "/src/MagicShop.Sale"
RUN dotnet build "MagicShop.SaleAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagicShop.SaleAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagicShop.SaleAPI.dll"]
