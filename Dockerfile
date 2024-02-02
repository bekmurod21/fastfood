FROM debian:buster-slim

RUN apt-get update
RUN apt-get install -y nginx

COPY ./src/FastFood.WebApi/bin/Release/net6.0/win-x64/publish ./var/www/FastFood

CMD [ "nginx","-g","daemon off; " ] 