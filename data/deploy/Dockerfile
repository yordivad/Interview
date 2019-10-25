FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder
WORKDIR /app

COPY . ./

# Restoring the packages
RUN dotnet restore
RUN dotnet publish -c Release -o /artifacts


FROM mcr.microsoft.com/dotnet/core/runtime:2.2 AS runtime
EXPOSE 8080
WORKDIR /app
COPY --from=builder /artifacts ./
ENTRYPOINT ["dotnet", "MCode.Interview.Data.App.dll"]
