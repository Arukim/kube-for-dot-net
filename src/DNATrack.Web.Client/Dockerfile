FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY [".","."]

RUN dotnet restore "DNATrack.Web.Client/DNATrack.Web.Client.csproj"
WORKDIR "/src/DNATrack.Web.Client"
RUN dotnet build "DNATrack.Web.Client.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DNATrack.Web.Client.csproj" -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT  ["dotnet", "DNATrack.Web.Client.dll"]