FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlueCube.Identity/BlueCube.Identity.csproj", "BlueCube.Identity/"]
COPY ["BlueCube.Models/BlueCube.Models.csproj", "BlueCube.Models/"]
COPY ["LiteChat/LiteChat.csproj", "LiteChat/"]

RUN dotnet restore "BlueCube.Identity/BlueCube.Identity.csproj"
COPY . .
WORKDIR "/src/BlueCube.Identity"

RUN dotnet build "BlueCube.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlueCube.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlueCube.Identity.dll"]
