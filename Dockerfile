#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ArithmeticWebApi/ArithmeticWebApi.csproj", "ArithmeticWebApi/"]
RUN dotnet restore "ArithmeticWebApi/ArithmeticWebApi.csproj"
COPY . .
WORKDIR "/src/ArithmeticWebApi"
RUN dotnet build "ArithmeticWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArithmeticWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArithmeticWebApi.dll"]