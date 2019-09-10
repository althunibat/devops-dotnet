#!/bin/sh
dotnet sonarscanner begin /k:${PJ_KEY} /d:sonar.host.url=${SONAR_HOST_URL} /d:sonar.login=${SONAR_AUTH_TOKEN}
dotnet build /app/src/Api/Api.csproj
dotnet sonarscanner end /d:sonar.login=${SONAR_AUTH_TOKEN}