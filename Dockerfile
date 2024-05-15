FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/SideKick.Api/SideKick.Api.csproj", "SideKick.Api/"]
COPY ["src/SideKick.Application/SideKick.Application.csproj", "SideKick.Application/"]
COPY ["src/SideKick.Domain/SideKick.Domain.csproj", "SideKick.Domain/"]
COPY ["src/SideKick.Contracts/SideKick.Contracts.csproj", "SideKick.Contracts/"]
COPY ["src/SideKick.Infrastructure/SideKick.Infrastructure.csproj", "SideKick.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "SideKick.Api/SideKick.Api.csproj"
COPY . ../
WORKDIR /src/SideKick.Api
RUN dotnet build "SideKick.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SideKick.Api.dll"]