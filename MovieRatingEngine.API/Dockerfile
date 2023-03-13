#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MovieRatingEngine.API/MovieRatingEngine.API.csproj", "MovieRatingEngine.API/"]
RUN dotnet restore "MovieRatingEngine.API/MovieRatingEngine.API.csproj"
COPY . .
WORKDIR "/src/MovieRatingEngine.API"
RUN dotnet build "MovieRatingEngine.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieRatingEngine.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieRatingEngine.API.dll"]