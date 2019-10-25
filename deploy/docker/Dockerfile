FROM mcr.microsoft.com/dotnet/core/sdk:2.2
WORKDIR /app


ARG SONARKEY
ARG APIKEY
ARG CIRCLE_BRANCH=master


RUN git clone https://github.com/RoyGI/Interview.git .

RUN git checkout $CIRCLE_BRANCH

ENV PATH="/root/.dotnet/tools:${PATH}"
RUN apt update
RUN apt -y install default-jdk
RUN dotnet tool install -g Cake.Tool
RUN dotnet tool install -g nbgv
RUN dotnet tool install -g dotnet-sonarscanner

WORKDIR /app/csharp
RUN dotnet cake --target=quality