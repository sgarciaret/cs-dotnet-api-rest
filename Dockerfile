FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CSApiRestPractice.csproj", "./"]
RUN dotnet restore "CSApiRestPractice.csproj"
COPY . .
RUN dotnet publish "CSApiRestPractice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "CSApiRestPractice.dll"]