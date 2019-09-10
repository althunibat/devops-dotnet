#!/bin/sh
dotnet test /app/test/UnitTests/UnitTests.csproj -r /reports --logger:trx /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=/reports/
