FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder
WORKDIR /app

# Restoring the packages
COPY . ./
RUN dotnet restore Epic.Interview.sln 

# Building 
WORKDIR ./Epic.Interview.Services
RUN dotnet publish -c publish -o dist

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=builder /app/Epic.Interview.Services/dist ./
ENTRYPOINT ["dotnet", "Epic.Interview.Services.dll"]

