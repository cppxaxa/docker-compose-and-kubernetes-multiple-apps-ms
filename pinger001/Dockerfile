# syntax=docker/dockerfile:1
FROM alpine:3.14
WORKDIR /app
RUN apk add --no-cache --update curl
COPY . .
CMD sh script.sh
