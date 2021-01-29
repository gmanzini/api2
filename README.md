# api2
API usada para calcular o valor do imóvel através do metro quadrado.


Docker File:

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /app
COPY ./ ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim
WORKDIR /app
COPY --from=build /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet API2.dll



Passos para publicação no heroku:

docker build -t api2-gmanzini .

heroku login

heroku container:login

docker tag api2-gmanzini registry.heroku.com/api2-gmanzini/web

heroku container:push web -a api2-gmanzini

heroku container:release web -a api2-gmanzini

https://api2-gmanzini.herokuapp.com/swagger/index.html
