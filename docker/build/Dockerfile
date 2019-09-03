
FROM  mcr.microsoft.com/dotnet/core/sdk:2.2-bionic
RUN apt update
RUN apt install -q -y libcurl3 openjdk-8-jre-headless
RUN dotnet tool install -g Cake.Tool
RUN dotnet tool install -g dotnet-sonarscanner
RUN dotnet tool install -g GitVersion.Tool
ENV PATH="${PATH}:/root/.dotnet/tools"


WORKDIR /app
COPY ./ .

RUN dotnet cake build.cake


