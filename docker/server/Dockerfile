FROM mcr.microsoft.com/dotnet/core/sdk:latest AS builder
WORKDIR /app

COPY *.sln .
COPY ./src ./src
COPY ./test ./test
COPY ./data ./data 

# Restoring the packages
RUN dotnet restore Epic.Interview.sln 

# Building 
WORKDIR /app/src/Epic.Interview.Services
RUN dotnet publish -c publish -o dist

FROM mcr.microsoft.com/dotnet/core/runtime:latest AS runtime
EXPOSE 8080
WORKDIR /app
COPY --from=builder /app/src/Epic.Interview.Services/dist ./
ENTRYPOINT ["dotnet", "Epic.Interview.Services.dll"]


