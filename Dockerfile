FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /source

COPY ./src ./
WORKDIR /src

CMD [ "dotnet","restore" ]
RUN dotnet publish -c Release -o test

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS serve
WORKDIR /app
COPY --from=build /src/test .

EXPOSE 80
EXPOSE 443
EXPOSE 5000
Expose 8080

VOLUME ["/app/uploads"]

ENTRYPOINT [ "dotnet", "ERP-System_Server.Api.dll" ]