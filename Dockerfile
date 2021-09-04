FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Recepdmr.Web/Recepdmr.Web.csproj", "Recepdmr.Web/"]
RUN dotnet restore "Recepdmr.Web/Recepdmr.Web.csproj"
COPY . .
WORKDIR "/src/Recepdmr.Web"
RUN dotnet build "Recepdmr.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recepdmr.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recepdmr.Web.dll"]
