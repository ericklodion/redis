#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ErickEspinosa.Redis.WebApi/ErickEspinosa.Redis.WebApi.csproj", "ErickEspinosa.Redis.WebApi/"]
RUN dotnet restore "ErickEspinosa.Redis.WebApi/ErickEspinosa.Redis.WebApi.csproj"
COPY . .
WORKDIR "/src/ErickEspinosa.Redis.WebApi"
RUN dotnet build "ErickEspinosa.Redis.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ErickEspinosa.Redis.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ErickEspinosa.Redis.WebApi.dll"]