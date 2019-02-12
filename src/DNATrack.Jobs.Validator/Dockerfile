FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY [".","."]

RUN dotnet restore "DNATrack.Jobs.Validator/DNATrack.Jobs.Validator.csproj"
WORKDIR "/src/DNATrack.Jobs.Validator"
RUN dotnet build "DNATrack.Jobs.Validator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DNATrack.Jobs.Validator.csproj" -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT  ["dotnet", "DNATrack.Jobs.Validator.dll"]