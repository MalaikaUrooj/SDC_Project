# Stage 1: Build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
WORKDIR /src

# Copy project files
COPY ["authorizedBasedProject/authorizedBasedProject.csproj", "authorizedBasedProject/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["UseCases/UseCases.csproj", "UseCases/"]

# Restore project dependencies
RUN dotnet restore "authorizedBasedProject/authorizedBasedProject.csproj"

# Copy the remaining application code
COPY . .

# Build the application in Release mode
WORKDIR "/src/authorizedBasedProject"
RUN dotnet build "authorizedBasedProject.csproj" -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "authorizedBasedProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Build the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS final
WORKDIR /app
EXPOSE 5218

# Copy the published files from the build stage
COPY --from=publish /app/publish ./

# Set the entry point for the application
ENTRYPOINT ["dotnet", "authorizedBasedProject.dll"]
