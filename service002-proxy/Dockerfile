# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY . .
# RUN dotnet dev-certs https
CMD dotnet run --project WebApiService --urls "http://0.0.0.0:80"
