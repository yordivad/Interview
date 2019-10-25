FROM roygi-docker-mdocker.bintray.io/dotnet/sdk:2.2
WORKDIR /app

ARG SONARKEY
ARG APIKEY
ARG CIRCLE_BRANCH=master

RUN git clone https://github.com/RoyGI/Interview.git .

RUN git checkout $CIRCLE_BRANCH

WORKDIR /app/csharp
RUN dotnet cake

