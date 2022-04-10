FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Dwapi.Prep/Dwapi.Prep.csproj", "Dwapi.Prep/"]
RUN dotnet restore "src/Dwapi.Prep/Dwapi.Prep.csproj"
COPY . .
WORKDIR "/src/Dwapi.Prep"
RUN dotnet build "Dwapi.Prep.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dwapi.Prep.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dwapi.Prep.dll"]
