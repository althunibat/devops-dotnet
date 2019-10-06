#!/bin/sh
dotnet test /app/test/IntegrationTests/IntegrationTests.csproj -r /reports --logger:trx 
