#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ASMS/ASMS.API/ASMS.API.csproj", "ASMS/ASMS.API/"]
COPY ["ASMS/ASMS.Command/ASMS.Command.csproj", "ASMS/ASMS.Command/"]
COPY ["ASMS/ASMS.Services/ASMS.Services.csproj", "ASMS/ASMS.Services/"]
COPY ["ASMS/ASMS.QueryBuilders/ASMS.QueryBuilders.csproj", "ASMS/ASMS.QueryBuilders/"]
COPY ["ASMS/ASMS.Services.Abstractions/ASMS.Services.Abstractions.csproj", "ASMS/ASMS.Services.Abstractions/"]
COPY ["ASMS/ASMS.DTOs/ASMS.DTOs.csproj", "ASMS/ASMS.DTOs/"]
COPY ["ASMS/ASMS.CrossCutting/ASMS.CrossCutting.csproj", "ASMS/ASMS.CrossCutting/"]
COPY ["ASMS/ASMS.Persistence/ASMS.Persistence.csproj", "ASMS/ASMS.Persistence/"]
COPY ["ASMS/ASMS.Persistence.Abstractions/ASMS.Persistence.Abstractions.csproj", "ASMS/ASMS.Persistence.Abstractions/"]
COPY ["ASMS/ASMS.Domain/ASMS.Domain.csproj", "ASMS/ASMS.Domain/"]
COPY ["ASMS/ASMS.Domain.Abstractions/ASMS.Domain.Abstractions.csproj", "ASMS/ASMS.Domain.Abstractions/"]
COPY ["ASMS/ASMS.Infrastructure/ASMS.Infrastructure.csproj", "ASMS/ASMS.Infrastructure/"]
COPY ["ASMS/ASMS.Infrastructure.Automapper/ASMS.Infrastructure.Automapper.csproj", "ASMS/ASMS.Infrastructure.Automapper/"]
COPY ["ASMS/ASMS.Queries/ASMS.Queries.csproj", "ASMS/ASMS.Queries/"]
RUN dotnet restore "./ASMS/ASMS.API/ASMS.API.csproj"
COPY . .
WORKDIR "/src/ASMS/ASMS.API"
RUN dotnet build "./ASMS.API.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ASMS.API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASMS.API.dll"]