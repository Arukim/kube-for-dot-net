FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY [".","."]

RUN dotnet restore "DNATrack.Services.Analysis/DNATrack.Services.Analysis.csproj"
WORKDIR "/src/DNATrack.Services.Analysis"
RUN dotnet build "DNATrack.Services.Analysis.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DNATrack.Services.Analysis.csproj" -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT  ["dotnet", "DNATrack.Services.Analysis.dll"]