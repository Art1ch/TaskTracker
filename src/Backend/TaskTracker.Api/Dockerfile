FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["TaskTracker.Api/TaskTracker.Api.csproj", "TaskTracker.Api/"]
COPY ["TaskTracker.Application/TaskTracker.Application.csproj", "TaskTracker.Application/"]
COPY ["TaskTracker.Core/TaskTracker.Core.csproj", "TaskTracker.Core/"]
COPY ["TaskTracker.Infrastructure/TaskTracker.Infrastructure.csproj", "TaskTracker.Infrastructure/"]

RUN dotnet restore "TaskTracker.Api/TaskTracker.Api.csproj"

COPY . .

WORKDIR "/src/TaskTracker.Api"

RUN dotnet publish "TaskTracker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "TaskTracker.Api.dll"]