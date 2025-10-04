# =========================
# BUILD STAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj và restore riêng để tận dụng cache
COPY ["TowerDefense-2D-API.csproj", "./"]
RUN dotnet restore "TowerDefense-2D-API.csproj"

# Copy toàn bộ source
COPY . .

# Build và publish ra thư mục /app/out
RUN dotnet publish "TowerDefense-2D-API.csproj" -c Release -o /app/out

# =========================
# RUNTIME STAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy build output từ stage trước
COPY --from=build /app/out .

# Expose port Render sẽ dùng
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# Entry point
ENTRYPOINT ["dotnet", "TowerDefense-2D-API.dll"]
